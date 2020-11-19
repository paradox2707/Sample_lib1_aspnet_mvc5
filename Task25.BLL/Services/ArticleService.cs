using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.BLL.DTO;
using Task25.BLL.Interfaces.IServices;
using Task25.DAL.Infrastructure.Interfaces;
using Task25.DAL.Entities;
using Task25.BLL.Infrustructure.Compare;
using System.Diagnostics;
using System.Collections;

namespace Task25.BLL.Services
{
    public class ArticleService: IArticleService
    {
        IUnitOfWork unitOfWork;

        public ArticleService(IUnitOfWork context)
        {
            unitOfWork = context;
        }

        public IEnumerable<ArticleDTO> GetAllArticle()
        {
            return MapManyArticlesToArticleDtos(unitOfWork.GetRepo<Article>().GetAll());
        }

        public ArticleDTO GetByID(int id)
        {
            return MapArticleToArticleDto(unitOfWork.GetRepo<Article>().GetById(id));
        }

        public bool ExistByID(int id)
        {
            return MapArticleToArticleDto(unitOfWork.GetRepo<Article>().GetById(id)) != null;
        }

        public void AddArticle(ArticleDTO articleDTO)
        {
            CreateNewTegsAndGetTrackingTegs(articleDTO);
            foreach (var teg in articleDTO.Tegs)
            {
                teg.Articles.Add(articleDTO);
            }

            articleDTO.Date = DateTime.Now;
            var article = MapArticleDtoToArticle(articleDTO, null); //TODO: emend mapping

            unitOfWork.GetRepo<Article>().Create(article);
            unitOfWork.Save();
        }

        public void UpdateArticle(ArticleDTO articleDTO)
        {
            foreach (var teg in articleDTO.Tegs)
            {
                teg.Articles.Add(articleDTO);
            }

            var trackTegs = CreateNewTegsAndGetTrackingTegs(articleDTO); 




            var repo = unitOfWork.GetRepo<Article>();
            var existArticle = repo.GetById(articleDTO.Id);
            var article = MapArticleDtoToArticle(articleDTO, existArticle);

            //Debug.WriteLine("newArticle - " + article.GetHashCode());
            //var existArticle = repo.GetById(article.Id);
            //Debug.WriteLine("existArticle - " + existArticle.GetHashCode());
            //var allExistTegs = unitOfWork.GetRepo<Teg>().GetAll();
            //existArticle.Title = article.Title;
            //var getTegs = allExistTegs.Intersect(article.Tegs.ToList(), new TegCompare());
            //article.Tegs = getTegs.ToList();
            //Debug.WriteLine("existArticle after change - " + existArticle.GetHashCode());
            //repo.Update(existArticle, "Tegs");

            article.Tegs = trackTegs.ToList();
            repo.Update(article);
            unitOfWork.Save();
        }

        public IEnumerable<Teg> CreateNewTegsAndGetTrackingTegs(ArticleDTO articleDTO)
        {


            var existTegs = unitOfWork.GetRepo<Teg>().GetAll();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Teg, TegDTO>();
                cfg.CreateMap<Article, ArticleDTO>().ForMember(dist => dist.Tegs, opt => opt.Ignore());
            }).CreateMapper();
            var existTegsDtos = mapper.Map<IEnumerable<Teg>, IEnumerable<TegDTO>>(existTegs);

            var newTegsDtos = articleDTO.Tegs.Except(existTegsDtos, new TegDTOCompare());
            var mapperToDal = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TegDTO, Teg>();
                cfg.CreateMap<ArticleDTO, Article>().ForMember(dist => dist.Tegs, opt => opt.Ignore());
            }).CreateMapper();
            var newTegs = mapperToDal.Map<IEnumerable<TegDTO>, IEnumerable<Teg>>(newTegsDtos);

            var repoTeg = unitOfWork.GetRepo<Teg>();
            foreach (var teg in newTegs)
            {
                repoTeg.Create(teg);
            }
            unitOfWork.Save();

            existTegs = unitOfWork.GetRepo<Teg>().GetAll();
            //existTegsDtos = mapper.Map<IEnumerable<Teg>, IEnumerable<TegDTO>>(existTegs);

            //var TegsDtosWithId = existTegsDtos.Intersect(articleDTO.Tegs, new TegDTOCompare());

            //articleDTO.Tegs = TegsDtosWithId.ToList();


            var listTegsDAO = mapperToDal.Map<IEnumerable<TegDTO>, IEnumerable<Teg>>(articleDTO.Tegs);
            var trackTegs = existTegs.Intersect(listTegsDAO, new TegCompare());

            
            return trackTegs;


        }

        ArticleDTO MapArticleToArticleDto(Article article)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Article, ArticleDTO>();
                cfg.CreateMap<Teg, TegDTO>().ForMember(dist => dist.Articles, opt => opt.Ignore());
            }).CreateMapper();
            return mapper.Map<Article, ArticleDTO>(article);
        }

        IEnumerable<ArticleDTO> MapManyArticlesToArticleDtos(IEnumerable<Article> articles)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Article, ArticleDTO>();
                cfg.CreateMap<Teg, TegDTO>().ForMember(dist => dist.Articles, opt => opt.Ignore());
            }).CreateMapper();
            return mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articles);
        }

        Article MapArticleDtoToArticle(ArticleDTO articleDto, Article article) //Article article
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDTO, Article>();
                cfg.CreateMap<TegDTO, Teg>();
            }).CreateMapper();

            return mapper.Map<ArticleDTO, Article>(articleDto, article);
        }

        IEnumerable<Article> MapManyArticleDtosToArticle(IEnumerable<ArticleDTO> articleDtos)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ArticleDTO, Article>();
                cfg.CreateMap<TegDTO, Teg>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<ArticleDTO>, IEnumerable<Article>>(articleDtos);
        }


        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    unitOfWork.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
