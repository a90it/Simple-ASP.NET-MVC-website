namespace MvcTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MvcTemplate.Data.Common.Models;

    public class VoteForSuggestion : BaseModel<int>
    {
        [Required]
        public int SuggestionId { get; set; }

        [ForeignKey("SuggestionId")]
        public virtual Suggestion Suggestion { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ApplicationUser Author { get; set; }
    }
}
