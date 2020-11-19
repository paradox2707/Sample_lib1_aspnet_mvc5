using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.DAL.Entities
{
    /// <summary>Comment entity schema</summary>
    public class Comment : BaseEntity
    {
        /// <summary>Gets or sets the author.</summary>
        /// <value>The author.</value>
        public string Author { get; set; }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the text.</summary>
        /// <value>The text.</value>
        public string Text { get; set; }
    }
}
