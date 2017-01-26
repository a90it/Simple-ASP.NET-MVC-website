namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MvcTemplate.Data.Models;

    public interface IPostsService
    {
        IQueryable<Post> GetAll();

        Post GetById(string id);

        void Create(Post post);

        IQueryable<Post> Search(string filter);

        void DeleteById(int id);
    }
}
