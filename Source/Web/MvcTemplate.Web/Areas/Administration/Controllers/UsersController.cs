﻿namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
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
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(UserViewModel viewModel)
        {
            if (this.ModelState.IsValid == true)
            {
                var changedUser = this.Mapper.Map<ApplicationUser>(viewModel);
                this.users.UpdateChanges(changedUser);
                return this.Redirect(string.Format("/Administration/Users/ById/{0}", viewModel.Id));
            }
            else
            {
                return this.View(viewModel);
            }
        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var userTemp = this.users.GetById(id);
            var user = this.Mapper.Map<UserViewModel>(userTemp);
            return this.View(user);
        }

        // TODO: HttpPost
        public ActionResult MakeAdministrator(string userId)
        {
            this.users.MakeAdministrator(userId);
            return this.Redirect("/Administration/Users/All");
        }
    }
}
