namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using Web;

    public class PostsService : IPostsService
    {
        private readonly IDbRepository<Post> posts;
        private readonly IIdentifierProvider identifierProvider;

        public PostsService(IDbRepository<Post> posts, IIdentifierProvider identifierProvider)
        {
            this.posts = posts;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Post> GetAll()
        {
            var posts = this.posts.All().OrderByDescending(x => x.CreatedOn);
            return posts;
        }

        public Post GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var post = this.posts.GetById(intId);
            return post;
        }

        public void DeleteById(int id)
        {
            var post = this.posts.GetById(id);
            this.posts.Delete(post);
            this.posts.Save();
        }

        public void Create(Post post)
        {
            this.posts.Add(post);
            this.posts.Save();
        }

        public IQueryable<Post> Search(string filter)
        {
            if (string.IsNullOrEmpty(filter) == true)
            {
                filter = null;
            }

            var posts = this.posts.All().Where(x => x.Title.Contains(filter)).OrderByDescending(x => x.CreatedOn);
            return posts;
        }
    }
}
