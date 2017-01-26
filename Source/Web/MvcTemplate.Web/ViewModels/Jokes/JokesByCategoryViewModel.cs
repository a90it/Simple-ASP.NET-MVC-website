namespace MvcTemplate.Web.ViewModels.Jokes
{
    using System.Collections.Generic;

    public class JokesByCategoryViewModel
    {
        public IEnumerable<JokeViewModel> Jokes { get; set; }

        public JokeCategoryViewModel Category { get; set; }
    }
}
