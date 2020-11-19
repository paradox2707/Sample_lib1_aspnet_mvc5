using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task25.Models
{
    public class TegViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<ArticleViewModel> Articles { get; set; }

    }
}