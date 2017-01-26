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
    using Services.Web;

    public class PostViewModel : IMapFrom<Post>, IMapTo<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Must be between 10 and 100 symbols long.", MinimumLength = 10)]
        public string Title { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Must be between 10 and 300 symbols long.", MinimumLength = 10)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public string Author { get; set; }

        public int CommentsCount { get; set; }

        public string CreatedOn { get; set; }

        public virtual ICollection<CommentViewModel> Comments { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Post/{identifier.EncodeId(this.Id)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.UserName));
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.AuthorId, opt => opt.MapFrom(x => x.Author.Id));
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.CommentsCount, opt => opt.MapFrom(x => x.Comments.Count));
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.CreatedOn, opt => opt.MapFrom(x => x.CreatedOn.ToString()));
         }
    }
}
