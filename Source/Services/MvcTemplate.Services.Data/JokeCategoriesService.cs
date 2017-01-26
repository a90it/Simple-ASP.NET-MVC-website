namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class JokeCategoriesService : IJokeCategoriesService
    {
        private readonly IDbRepository<JokeCategory> categories;

        public JokeCategoriesService(IDbRepository<JokeCategory> categories)
        {
            this.categories = categories;
        }

        public JokeCategory EnsureCategory(string name)
        {
            var category = this.categories.All().FirstOrDefault(x => x.Name == name);
            if (category != null)
            {
                return category;
            }

            category = new JokeCategory { Name = name };
            this.categories.Add(category);
            this.categories.Save();
            return category;
        }

        public IQueryable<JokeCategory> GetAll()
        {
            return this.categories.All().OrderBy(x => x.Name);
        }

        public JokeCategory GetById(string id)
        {
            var category = this.categories.GetById(int.Parse(id));
            return category;
        }
    }
}
