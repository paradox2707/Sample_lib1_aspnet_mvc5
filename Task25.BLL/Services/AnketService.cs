using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.BLL.Interfaces.IServices;
using Task25.DAL.Infrastructure.Interfaces;
using Task25.DAL.Entities;
using AutoMapper;
using Task25.BLL.DTO;

namespace Task25.BLL.Services
{
    public class AnketService: IAnketService
    {
        IUnitOfWork unitOfWork;

        public AnketService(IUnitOfWork context)
        {
            unitOfWork = context;
        }

        public AnketDTO GetAnketByName(string name)
        {

            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<Anket, AnketDTO>();
                cfg.CreateMap<AnketChoice, AnketChoiceDTO>();
                cfg.CreateMap<AnketQuestion, AnketQuestionDTO>();
                cfg.CreateMap<AnketResponse, AnketResponseDTO>();
                cfg.CreateMap<AnswerCheckBox, AnswerCheckBoxDTO>();
                cfg.CreateMap<QuestionType, QuestionTypeDTO>();
            }).CreateMapper();
            return mapper.Map<IEnumerable<Anket>, List<AnketDTO>>(unitOfWork.GetRepo<Anket>().GetAll()).SingleOrDefault(x => x.Title == name);
        }

        public void AddResponse(AnketResponseDTO responseDTO)
        {
            var mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<AnketResponseDTO, AnketResponse>();
                cfg.CreateMap<AnswerCheckBoxDTO, AnswerCheckBox>();
            }).CreateMapper();
            var response = mapper.Map<AnketResponseDTO, AnketResponse>(responseDTO);
            unitOfWork.GetRepo<AnketResponse>().Create(response);
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
