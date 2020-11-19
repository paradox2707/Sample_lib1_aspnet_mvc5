using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task25.Models.Pagination
{
    public class PageArticlesViewModel
    {
        public IEnumerable<ArticleViewModel> Articles { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}