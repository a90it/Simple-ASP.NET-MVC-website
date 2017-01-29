namespace MvcTemplate.Web.ViewModels.Jokes
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Infrastructure.Mapping;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Web;

    public class JokeViewModel : IMapFrom<Joke>, IMapTo<Joke>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Must be between 10 and 300 symbols long.", MinimumLength = 10)]
        public string Content { get; set; }

        [StringLength(20, ErrorMessage = "Must be between 3 and 20 symbols long.", MinimumLength = 3)]
        public string Category { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Joke/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Joke, JokeViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
