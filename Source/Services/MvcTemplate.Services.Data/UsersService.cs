namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class UsersService : IUsersService
    {
        private readonly IDbGenericRepository<ApplicationUser, string> users;
        private readonly UserManager<ApplicationUser> manager;

        public UsersService(IDbGenericRepository<ApplicationUser, string> users, UserManager<ApplicationUser> manager)
        {
            this.users = users;
            this.manager = manager;
        }

        public void UpdateChanges(ApplicationUser changedUser)
        {
            var user = this.users.GetById(changedUser.Id);
            user.UserName = changedUser.UserName;
            user.Email = changedUser.Email;
            this.users.Save();
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

        public void MakeAdministrator(string userId)
        {
            var user = this.GetById(userId);
            this.manager.AddToRole(user.Id, "Administrator");
        }
    }
}
