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
            if (userTemp.Roles.Any() == true)
            {
                user.Role = GlobalConstants.AdministratorRoleName;
            }
            else
            {
                user.Role = GlobalConstants.NormalUserRoleName;
            }

            return this.View(user);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel viewModel)
        {
            var changedUser = this.users.GetById(viewModel.Id);

            // TODO: use automapper for mapping instead
            changedUser.UserName = viewModel.UserName;
            changedUser.Email = viewModel.Email;
            this.users.UpdateChanges(changedUser);
            return this.Redirect(string.Format("/Administration/Users/ById/{0}", viewModel.Id));
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var userTemp = this.users.GetById(id);
            var user = this.Mapper.Map<UserViewModel>(userTemp);
            return this.View(user);
        }
    }
}
