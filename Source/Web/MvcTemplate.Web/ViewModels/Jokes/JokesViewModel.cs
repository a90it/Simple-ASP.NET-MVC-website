namespace MvcTemplate.Web.ViewModels.Jokes
{
    using System.Collections.Generic;

    public class JokesViewModel
    {
        public IEnumerable<JokeViewModel> Jokes { get; set; }

        public IEnumerable<JokeCategoryViewModel> Categories { get; set; }
    }
}
