using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.BLL.DTO
{
    public class AnketDTO
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>Gets or sets the questions.</summary>
        /// <value>The questions.</value>
        public virtual ICollection<AnketQuestionDTO> Questions { get; set; }

        /// <summary>Gets or sets the responses.</summary>
        /// <value>The responses.</value>
        public virtual ICollection<AnketResponseDTO> Responses { get; set; }
    }
}
