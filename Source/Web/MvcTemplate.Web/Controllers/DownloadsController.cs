namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class DownloadsController : BaseController
    {
        public ActionResult All()
        {
            return this.View();
        }

        public ActionResult Info()
        {
            string file = "~/App_Data/test.txt";
            string contentType = "text/plain";
            return this.File(file, contentType, Path.GetFileName(file));
        }

        public ActionResult Summator()
        {
            string file = "~/App_Data/Summator.exe";
            string contentType = "application/octet-stream";
            return this.File(file, contentType, Path.GetFileName(file));
        }
    }
}
