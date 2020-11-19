using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task25.Models.Pagination
{
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } 
        public int TotalItems { get; set; } 
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}