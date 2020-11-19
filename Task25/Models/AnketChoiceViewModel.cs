using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task25.Models
{
    public class AnketChoiceViewModel
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the question identifier.</summary>
        /// <value>The question identifier.</value>
        public int? QuestionId { get; set; }
        /// <summary>Gets or sets the question.</summary>
        /// <value>The question.</value>
        public virtual AnketQuestionViewModel Question { get; set; }
    }
}