using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.DAL.Entities
{
    /// <summary>Article entity schema</summary>
    public class Article : BaseEntity
    {
        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the text.</summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        public virtual ICollection<Teg> Tegs { get; set; }
        public Article()
        {
            Tegs = new HashSet<Teg>();
        }
    }
}
