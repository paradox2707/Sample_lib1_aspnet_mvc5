using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.DAL.Entities
{
    public class Teg: BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public Teg()
        {
            Articles = new HashSet<Article>();
        }
    }
}
