namespace MvcTemplate.Services.Data
{
    using System.Linq;
    using MvcTemplate.Data.Models;

    public interface ISuggestionService
    {
        IQueryable<Suggestion> GetAll();

        Suggestion GetById(string id);

        void Create(Suggestion suggestion);

        bool CurrentUserHasVoted(string user, string suggestionId);

        void DeleteById(int id);
    }
}
