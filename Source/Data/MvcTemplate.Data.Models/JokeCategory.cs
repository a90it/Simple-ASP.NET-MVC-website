namespace MvcTemplate.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MvcTemplate.Data.Common.Models;

    public class JokeCategory : BaseModel<int>
    {
        public JokeCategory()
        {
            this.Jokes = new HashSet<Joke>();
        }

        [Required]
        [StringLength(20, ErrorMessage = "Must be between 3 and 20", MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Joke> Jokes { get; set; }
    }
}
