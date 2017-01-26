namespace MvcTemplate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MvcTemplate.Data.Common.Models;

    public class Suggestion : BaseModel<int>
    {
        public Suggestion()
        {
            this.Votes = new HashSet<VoteForSuggestion>();
        }

        [Required]
        [StringLength(100, ErrorMessage = "Must be between 10 and 100", MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Must be between 10 and 300", MinimumLength = 10)]
        public string Content { get; set; }

        public virtual ICollection<VoteForSuggestion> Votes { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }
    }
}
