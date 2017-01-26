namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common;
    using Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class UsersController : BaseController
    {
        public ActionResult All()
        {
            return this.View();
        }
    }
}
