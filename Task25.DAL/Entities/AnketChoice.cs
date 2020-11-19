using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.DAL.Entities
{
    /// <summary>AnketChoice entity schema</summary>
    public class AnketChoice : BaseEntity
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the question identifier.</summary>
        /// <value>The question identifier.</value>
        public int? QuestionId { get; set; }
        /// <summary>Gets or sets the question.</summary>
        /// <value>The question.</value>
        public virtual AnketQuestion Question { get; set; }
    }
}
