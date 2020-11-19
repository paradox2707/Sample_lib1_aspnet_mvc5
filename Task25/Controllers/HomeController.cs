using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task25.BLL.DTO;
using Task25.BLL.Interfaces.IServices;
using Task25.Models;
using Task25.Models.Pagination;
using Task25.Infrustructure.Extensions;

namespace Task25.Controllers
{
    public class HomeController : Controller
    {
        IArticleService artService;
        ITegService tegServ;
        static int creatArticle;

        public HomeController(IArticleService articleServ, ITegService tegServ)
        {
            artService = articleServ;
            this.tegServ = tegServ;
        }

        public ActionResult Index(int page = 1)
        {
            //if (creatArticle == 0)
            //{
            //    //var teg = new TegDTO() { Name = "Curious" };
            //    //tegServ.AddTeg(teg);
            //    var tegDTO = tegServ.GetByID(1);
            //    var tegDTOs = new List<TegDTO> { tegDTO };
            //    var articleDTO = new ArticleDTO() { Title = "CreateTag1", Date = DateTime.Now, Tegs = tegDTOs };
            //    //var mapperArt = new MapperConfiguration(cfg =>
            //    //{
            //    //    cfg.CreateMap<ArticleViewModel, ArticleDTO>();
            //    //    cfg.CreateMap<TegViewModel, TegDTO>();
            //    //}).CreateMapper();
            //    //var article = mapperArt.Map<ArticleViewModel, ArticleDTO>(articleVM);
            //    artService.AddArticle(articleDTO);
            //    creatArticle = 1;
            //}

            int pageSize = 5;
            IEnumerable<ArticleDTO> articleDtos = artService.GetAllArticle();
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ArticleDTO, ArticleViewModel>();
                cfg.CreateMap<TegDTO, TegViewModel>();
            }).CreateMapper();
            var articles = mapper.Map<IEnumerable<ArticleDTO>, List<ArticleViewModel>>(articleDtos);
            IEnumerable<ArticleViewModel> articlePerPages = articles.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = articles.Count };
            PageArticlesViewModel ivm = new PageArticlesViewModel { PageInfo = pageInfo, Articles = articlePerPages };
            ivm.Articles.manyForPreview(200);
            return View(ivm);

        }


        public ActionResult Article(int id)
        {
            ArticleDTO articleDto = artService.GetByID(id);
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ArticleDTO, ArticleViewModel>();
                cfg.CreateMap<TegDTO, TegViewModel>();
            }).CreateMapper();
            var article = mapper.Map<ArticleDTO, ArticleViewModel>(articleDto);

            
            if(article is null)
            {
                return RedirectToAction("Index");
            }

            return View(article);
        }

        [HttpPost]
        public ActionResult Article(ArticleViewModel article)
        {
            //TryUpdateModel(article);
            if (artService.ExistByID(article.Id)) //
            {
                var mapper = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ArticleViewModel, ArticleDTO > ();
                    cfg.CreateMap<TegViewModel, TegDTO>();
                }).CreateMapper();
                var articleDto = mapper.Map<ArticleViewModel, ArticleDTO>(article);

                artService.UpdateArticle(articleDto);
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => {
                    cfg.CreateMap<ArticleViewModel, ArticleDTO>();
                    cfg.CreateMap<TegViewModel, TegDTO>();
                }).CreateMapper();
                var articleDto = mapper.Map<ArticleViewModel, ArticleDTO>(article);

                artService.AddArticle(articleDto);
            }
            
            

            if (article is null)
            {
                return RedirectToAction("Index");
            }

            return View(article);
        }

        public ActionResult EditArticle(int id)
        {
            ArticleDTO articleDto = artService.GetByID(id);
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ArticleDTO, ArticleViewModel>();
                cfg.CreateMap<TegDTO, TegViewModel>();
            }).CreateMapper();
            var article = mapper.Map<ArticleDTO, ArticleViewModel>(articleDto);


            if (article is null)
            {
                return View(new ArticleViewModel());
            }

            return View(article);
        }

        protected override void Dispose(bool disposing)
        {
            artService.Dispose();
            tegServ.Dispose();
            base.Dispose(disposing);
        }

    }
}