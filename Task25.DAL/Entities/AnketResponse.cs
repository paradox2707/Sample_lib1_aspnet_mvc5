using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.DAL.Entities
{
    /// <summary>AnketResponse entity schema</summary>
    public class AnketResponse : BaseEntity
    {
        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the name of the second.</summary>
        /// <value>The name of the second.</value>
        public string SecondName { get; set; }

        /// <summary>Gets or sets the b date.</summary>
        /// <value>The b date.</value>
        [DataType(DataType.Date)]
        public DateTime BDate { get; set; }

        /// <summary>Gets or sets the often visit.</summary>
        /// <value>The often visit.</value>
        public string OftenVisit { get; set; }

        /// <summary>Gets or sets the find service.</summary>
        /// <value>The find service.</value>
        public virtual IList<AnswerCheckBox> FindService { get; set; }

        /// <summary>Gets or sets the edu.</summary>
        /// <value>The edu.</value>
        public string Edu { get; set; }

        /// <summary>Gets or sets the employment status.</summary>
        /// <value>The employment status.</value>
        public string EmploymentStatus { get; set; }

        /// <summary>Gets or sets the services better.</summary>
        /// <value>The services better.</value>
        public string ServicesBetter { get; set; }

        /// <summary>Gets or sets the anket identifier.</summary>
        /// <value>The anket identifier.</value>
        public int? AnketId { get; set; }
        /// <summary>Gets or sets the anket.</summary>
        /// <value>The anket.</value>
        public virtual Anket Anket { get; set; }

    }
}
