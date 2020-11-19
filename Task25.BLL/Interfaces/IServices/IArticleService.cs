using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task25.BLL.DTO;

namespace Task25.BLL.Interfaces.IServices
{
    public interface IArticleService : IDisposable
    {
        IEnumerable<ArticleDTO> GetAllArticle();

        ArticleDTO GetByID(int id);

        bool ExistByID(int id);

        void AddArticle(ArticleDTO articleDTO);

        void UpdateArticle(ArticleDTO articleDTO);
    }
}
