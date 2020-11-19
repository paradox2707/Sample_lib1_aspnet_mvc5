using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task25.Models.Pagination
{
    public class PageCommentsViewModel
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}