namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;

    public class ContactsController : BaseController
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
