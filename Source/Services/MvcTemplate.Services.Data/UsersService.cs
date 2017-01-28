namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDbGenericRepository<ApplicationUser, string> users;

        public UsersService(IDbGenericRepository<ApplicationUser, string> users)
        {
            this.users = users;
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return this.users.All().OrderBy(x => x.UserName);
        }

        public ApplicationUser GetById(string id)
        {
            var user = this.users.GetById(id);
            return user;
        }
    }
}
