namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using Web;

    public class SuggestionsService : ISuggestionService
    {
        private readonly IDbRepository<Suggestion> suggestions;
        private readonly IDbRepository<Vote> votes;
        private readonly IIdentifierProvider identifierProvider;

        public SuggestionsService(IDbRepository<Suggestion> suggestions, IDbRepository<Vote> votes, IIdentifierProvider identifierProvider)
        {
            this.suggestions = suggestions;
            this.identifierProvider = identifierProvider;
            this.votes = votes;
        }

        public IQueryable<Suggestion> GetAll()
        {
            var suggestions = this.suggestions.All().OrderByDescending(x => x.Votes.Count);
            return suggestions;
        }

        public Suggestion GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            var suggestion = this.suggestions.GetById(intId);
            return suggestion;
        }

        public void Create(Suggestion suggestion)
        {
            this.suggestions.Add(suggestion);
            this.suggestions.Save();
        }

        public bool CurrentUserHasVoted(string userId, string suggestionId)
        {
            bool userHasVoted = false;
            int suggestionIdInt = this.identifierProvider.DecodeId(suggestionId);
            var vote = this.votes.All().FirstOrDefault(x => x.AuthorId == userId && x.SuggestionId == suggestionIdInt);
            if (vote != null)
            {
                userHasVoted = true;
            }

            return userHasVoted;
        }

        public void DeleteById(int id)
        {
            var suggestion = this.suggestions.GetById(id);
            this.suggestions.Delete(suggestion);
            this.suggestions.Save();
        }
    }
}
