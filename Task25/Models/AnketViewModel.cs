using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task25.Models
{
    public class AnketViewModel
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>Gets or sets the questions.</summary>
        /// <value>The questions.</value>
        public virtual ICollection<AnketQuestionViewModel> Questions { get; set; }

        /// <summary>Gets or sets the responses.</summary>
        /// <value>The responses.</value>
        public virtual ICollection<AnketResponseViewModel> Responses { get; set; }

        public AnketQuestionViewModel this[string name]
        {
            get
            {
                return this.Questions.SingleOrDefault(x => x.Name == name);
            }
        }
    }
}