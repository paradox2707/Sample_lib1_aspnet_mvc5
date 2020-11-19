using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using Task25.Models;

namespace Task25.Infrustructure.Extensions
{
    public static class ArticleExtension
    {
        public static ArticleViewModel oneForPreview(this ArticleViewModel article, int numberForPreview)
        {
            if (article.Text?.Length > numberForPreview)
            {
                article.TextPreview = article.Text?.Substring(0, numberForPreview);
                article.TextPostview = article.Text?.Substring(numberForPreview);
            }
            else
            {
                article.TextPreview = article.Text;
            }
            return article;
        }

        public static IEnumerable<ArticleViewModel> manyForPreview(this IEnumerable<ArticleViewModel> articles, int numberForPreview)
        {
            foreach(var item in articles)
            {
                item.oneForPreview(numberForPreview);
            }
            return articles;
        }

    }
}