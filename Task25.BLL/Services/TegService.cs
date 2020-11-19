using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Task25.BLL.DTO;
using Task25.BLL.Infrustructure.Compare;
using Task25.BLL.Interfaces.IServices;
using Task25.DAL.Entities;
using Task25.DAL.Infrastructure.Interfaces;

namespace Task25.BLL.Services
{
    public class TegService: ITegService
    {
        IUnitOfWork unitOfWork;

        public TegService(IUnitOfWork context)
        {
            unitOfWork = context;
        }

        public void AddTeg(TegDTO tegDTO)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TegDTO, Teg>()).CreateMapper();
            var teg = mapper.Map<TegDTO, Teg>(tegDTO);
            unitOfWork.GetRepo<Teg>().Create(teg);
            unitOfWork.Save();
        }

        public TegDTO GetByID(int id)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Teg, TegDTO>();
                cfg.CreateMap<Article, ArticleDTO>();
            }).CreateMapper();
            return mapper.Map<Teg, TegDTO>(unitOfWork.GetRepo<Teg>().GetById(id));
        }

        public void CreateNewTegsIfNotExist(IEnumerable<TegDTO> tegs)
        {


            var existTegs = unitOfWork.GetRepo<Teg>().GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap< IEnumerable<Teg>, IEnumerable<TegDTO>>()).CreateMapper();
            var existTegsDtos = mapper.Map< IEnumerable<Teg>, IEnumerable<TegDTO> >(existTegs);

            var newTegsDtos = existTegsDtos.Except(tegs, new TegDTOCompare());
            var mapperToDal = new MapperConfiguration(cfg => cfg.CreateMap<IEnumerable<TegDTO>, IEnumerable<Teg>>()).CreateMapper();
            var newTegs = mapperToDal.Map<IEnumerable<TegDTO>, IEnumerable<Teg>>(newTegsDtos);

            var repoTeg = unitOfWork.GetRepo<Teg>();
            foreach (var teg in newTegs)
            {
                repoTeg.Create(teg);
            }
            unitOfWork.Save();
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
