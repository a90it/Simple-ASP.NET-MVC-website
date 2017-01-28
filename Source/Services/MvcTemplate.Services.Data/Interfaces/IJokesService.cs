namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);

        IQueryable<Joke> GetByCategory(int categoryId);

        void DeleteById(int id);
    }
}
