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

namespace Task25.BLL.Services
{
    public class CommentService : ICommentService
    {
        readonly IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork dbContext)
        {
            this.unitOfWork = dbContext;
        }

        public void Add(CommentDTO comment)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, Comment > ()).CreateMapper();
            Comment commentMap = mapper.Map<CommentDTO, Comment>(comment);
            unitOfWork.GetRepo<Comment>().Create(commentMap);
            unitOfWork.Save();
        }

        public IEnumerable<CommentDTO> GetAllComments()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(unitOfWork.GetRepo<Comment>().GetAll());
        }

        public IEnumerable<CommentDTO> GetAllCommentsSortBy(Func<CommentDTO, dynamic> condition)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(unitOfWork.GetRepo<Comment>().GetAll()).OrderBy(condition);
        }

        public IEnumerable<CommentDTO> GetAllCommentsSortByDesc(Func<CommentDTO, dynamic> condition)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(unitOfWork.GetRepo<Comment>().GetAll()).OrderByDescending(condition);
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
