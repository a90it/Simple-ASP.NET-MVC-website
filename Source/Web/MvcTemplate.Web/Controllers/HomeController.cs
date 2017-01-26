namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;

    public class HomeController : BaseController
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}
