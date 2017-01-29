namespace MvcTemplate.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using MvcTemplate.Common;
    using MvcTemplate.Web.Controllers;
    using Services.Data;
    using Web.ViewModels.Jokes;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class ManageJokesController : BaseController
    {
        private readonly IJokesService jokes;
        private readonly IJokeCategoriesService categories;

        public ManageJokesController(IJokesService jokes, IJokeCategoriesService categories)
        {
            this.jokes = jokes;
            this.categories = categories;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JokeViewModel viewModel)
        {
            // TODO: use automapper for mapping instead
            var joke = new Joke();
            joke.Content = viewModel.Content;
            var category = this.categories.EnsureCategory(viewModel.Category);
            joke.Category = category;
            this.jokes.Create(joke);
            return this.Redirect("/Administration/AdminHome/Index");
        }
    }
}
