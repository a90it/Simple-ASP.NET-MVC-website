namespace MvcTemplate.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MvcTemplate.Data.Common.Models;

    public class Joke : BaseModel<int>
    {
        [Required]
        [StringLength(300, ErrorMessage = "Must be between 10 and 300", MinimumLength = 10)]
        public string Content { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual JokeCategory Category { get; set; }
    }
}
