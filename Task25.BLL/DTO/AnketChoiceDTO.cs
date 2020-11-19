using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.BLL.DTO
{
    public class AnketChoiceDTO
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
        public virtual AnketQuestionDTO Question { get; set; }
    }
}
