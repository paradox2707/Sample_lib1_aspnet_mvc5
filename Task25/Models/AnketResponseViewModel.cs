using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task25.Models
{
    public class AnketResponseViewModel
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z\s`-]+$", ErrorMessage = "(client) - Name must be only latin alphabet (can use - ` )")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the name of the second.</summary>
        /// <value>The name of the second.</value>
        [Required]
        [Remote("SurnameValidate", "Anket")]
        public string SecondName { get; set; }

        /// <summary>Gets or sets the b date.</summary>
        /// <value>The b date.</value>
        [Required]
        [DataType(DataType.Date)]
        public DateTime BDate { get; set; }

        /// <summary>Gets or sets the often visit.</summary>
        /// <value>The often visit.</value>
        [Required]
        public string OftenVisit { get; set; }

        /// <summary>Gets or sets the find service.</summary>
        /// <value>The find service.</value>
        [Required]
        public virtual IList<AnswerCheckBoxViewModel> FindService { get; set; }

        /// <summary>Gets or sets the edu.</summary>
        /// <value>The edu.</value>
        [Required]
        public string Edu { get; set; }

        /// <summary>Gets or sets the employment status.</summary>
        /// <value>The employment status.</value>
        [Required]
        public string EmploymentStatus { get; set; }

        /// <summary>Gets or sets the services better.</summary>
        /// <value>The services better.</value>
        [Required]
        public string ServicesBetter { get; set; }

        /// <summary>Gets or sets the anket identifier.</summary>
        /// <value>The anket identifier.</value>
        public int? AnketId { get; set; }
        /// <summary>Gets or sets the anket.</summary>
        /// <value>The anket.</value>
        public virtual AnketViewModel Anket { get; set; }
    }
}