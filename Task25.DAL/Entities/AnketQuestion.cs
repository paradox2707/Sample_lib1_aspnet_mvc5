using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.DAL.Entities
{
    /// <summary>AnketQuestion entity schema</summary>
    public class AnketQuestion : BaseEntity
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>Gets or sets the type of the q.</summary>
        /// <value>The type of the q.</value>
        public virtual QuestionType QType { get; set; }

        /// <summary>Gets or sets the anket identifier.</summary>
        /// <value>The anket identifier.</value>
        public int? AnketId { get; set; }
        /// <summary>Gets or sets the anket.</summary>
        /// <value>The anket.</value>
        public virtual Anket Anket { get; set; }

        /// <summary>Gets or sets the anket choices.</summary>
        /// <value>The anket choices.</value>
        public virtual ICollection<AnketChoice> AnketChoices { get; set; }

    }
}
