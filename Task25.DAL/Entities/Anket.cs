using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.DAL.Entities
{
    /// <summary>Anket entity schema</summary>
    public class Anket : BaseEntity
    {
        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>Gets or sets the questions.</summary>
        /// <value>The questions.</value>
        public virtual ICollection<AnketQuestion> Questions { get; set; }

        /// <summary>Gets or sets the responses.</summary>
        /// <value>The responses.</value>
        public virtual ICollection<AnketResponse> Responses { get; set; }

    }
}
