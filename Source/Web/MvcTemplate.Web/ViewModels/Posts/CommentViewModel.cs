namespace MvcTemplate.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IMapTo<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Must be between 3 and 100 symbols long.", MinimumLength = 3)]
        public string Content { get; set; }

        public string CreatorId { get; set; }

        public string Creator { get; set; }

        public int PostId { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Creator, opt => opt.MapFrom(x => x.Author.UserName));
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.CreatorId, opt => opt.MapFrom(x => x.Author.Id))
                .ReverseMap();
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.CreatedOn, opt => opt.MapFrom(x => x.CreatedOn.ToString()));
        }
    }
}
