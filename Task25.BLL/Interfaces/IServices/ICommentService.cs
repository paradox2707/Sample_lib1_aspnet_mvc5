using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.BLL.DTO;

namespace Task25.BLL.Interfaces.IServices
{
    public interface ICommentService : IDisposable
    {
        IEnumerable<CommentDTO> GetAllComments();
        IEnumerable<CommentDTO> GetAllCommentsSortBy(Func<CommentDTO, dynamic> condition);
        IEnumerable<CommentDTO> GetAllCommentsSortByDesc(Func<CommentDTO, dynamic> condition);
        void Add(CommentDTO comment);
    }
}
