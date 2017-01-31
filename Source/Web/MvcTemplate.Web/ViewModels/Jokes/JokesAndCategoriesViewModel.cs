namespace MvcTemplate.Web.ViewModels.Jokes
{
    using System.Collections.Generic;

    public class JokesAndCategoriesViewModel
    {
        public IEnumerable<JokeViewModel> Jokes { get; set; }

        public IEnumerable<JokeCategoryViewModel> Categories { get; set; }
    }
}
