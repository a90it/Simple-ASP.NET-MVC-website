namespace MvcTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using MvcTemplate.Services.Data;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using ViewModels.Jokes;

    public class JokesController : BaseController
    {
        private readonly IJokesService jokes;
        private readonly IJokeCategoriesService jokeCategories;

        public JokesController(
            IJokesService jokes, IJokeCategoriesService jokeCategories)
        {
            this.jokes = jokes;
            this.jokeCategories = jokeCategories;
        }

        public ActionResult Random()
        {
            var jokes = this.jokes.GetRandomJokes(3).To<JokeViewModel>().ToList();
            var categories =
                this.Cache.Get(
                    "categories",
                    () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
                    30 * 60);
            var viewModel = new JokesViewModel
            {
                Jokes = jokes,
                Categories = categories
            };

            return this.View(viewModel);
        }

        public ActionResult ById(string id)
        {
            var joke = this.jokes.GetById(id);
            var viewModel = this.Mapper.Map<JokeViewModel>(joke);
            return this.View(viewModel);
        }

        public ActionResult Category(string id)
        {
            var categoryTemp = this.jokeCategories.GetById(id);
            var category = this.Mapper.Map<JokeCategoryViewModel>(categoryTemp);
            var jokes = this.jokes.GetByCategory(int.Parse(id)).To<JokeViewModel>();
            var viewModel = new JokesByCategoryViewModel()
            {
                Jokes = jokes,
                Category = category
            };
            return this.View(viewModel);
        }
    }
}
