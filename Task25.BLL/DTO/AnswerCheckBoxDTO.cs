﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task25.BLL.DTO
{
    public class AnswerCheckBoxDTO
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>Gets or sets the option.</summary>
        /// <value>The option.</value>
        public string Option { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="AnswerCheckBox" /> is state.</summary>
        /// <value>
        ///   <c>true</c> if state; otherwise, <c>false</c>.</value>
        public bool State { get; set; }

        /// <summary>Gets or sets the response identifier.</summary>
        /// <value>The response identifier.</value>
        public int? ResponseId { get; set; }
        /// <summary>Gets or sets the response.</summary>
        /// <value>The response.</value>
        public virtual AnketResponseDTO Response { get; set; }
    }
}
