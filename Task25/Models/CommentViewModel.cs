using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Task25.Models.Pagination;

namespace Task25.Models
{
    public class CommentViewModel
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>Gets or sets the author.</summary>
        /// <value>The author.</value>
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        public string Author { get; set; }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the text.</summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        public PageCommentsViewModel PageComments { get; set; }
    }
}