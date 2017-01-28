namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Users;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : BaseController
    {
        private readonly IUsersService users;

        public UsersController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult All()
        {
            var users = this.users.GetAll().To<UserViewModel>().ToList();
            return this.View(users);
        }

        public ActionResult ById(string id)
        {
            var userTemp = this.users.GetById(id);
            var user = this.Mapper.Map<UserViewModel>(userTemp);
            return this.View(user);
        }
    }
}
