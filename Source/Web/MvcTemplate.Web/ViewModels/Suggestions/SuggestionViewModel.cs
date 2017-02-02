namespace MvcTemplate.Web.ViewModels.Suggestions
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Services.Web;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class SuggestionViewModel : IMapFrom<Suggestion>, IMapTo<Suggestion>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Must be between 10 and 100 symbols long.", MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Must be between 10 and 300 symbols long.", MinimumLength = 10)]
        public string Content { get; set; }

        public string CreatorId { get; set; }

        public string Creator { get; set; }

        public int UpVotes { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Suggestion/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Suggestion, SuggestionViewModel>()
                .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Author.UserName));
            configuration.CreateMap<Suggestion, SuggestionViewModel>()
                .ForMember(x => x.CreatorId, opt => opt.MapFrom(x => x.Author.Id))
                .ReverseMap();
            configuration.CreateMap<Suggestion, SuggestionViewModel>()
                .ForMember(x => x.UpVotes, opt => opt.MapFrom(x => x.Votes.Count));
        }
    }
}
