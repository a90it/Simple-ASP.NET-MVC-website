namespace MvcTemplate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MvcTemplate.Data.Common.Models;

    public class Post : BaseModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        [StringLength(100, ErrorMessage = "Must be between 10 and 100", MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Must be between 10 and 300", MinimumLength = 10)]
        public string Content { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }
    }
}
