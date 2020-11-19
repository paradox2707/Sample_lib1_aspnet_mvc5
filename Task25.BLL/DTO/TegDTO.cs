using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.BLL.DTO
{
    public class TegDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<ArticleDTO> Articles { get; set; }
    }
}
