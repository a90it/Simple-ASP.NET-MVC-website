namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);

        void DeleteById(int id);

        void Create(Joke joke);
    }
}
