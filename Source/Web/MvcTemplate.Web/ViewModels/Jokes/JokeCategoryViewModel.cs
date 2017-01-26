namespace MvcTemplate.Web.ViewModels.Jokes
{
    using System.ComponentModel.DataAnnotations;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Must be between 3 and 20 symbols long.", MinimumLength = 3)]
        public string Name { get; set; }

        public string Url
        {
            get
            {
                return $"/Category/{this.Id}";
            }
        }
    }
}
