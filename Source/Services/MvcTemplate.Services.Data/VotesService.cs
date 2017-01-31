namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IDbRepository<Vote> votes;

        public VotesService(IDbRepository<Vote> votes)
        {
            this.votes = votes;
        }

        public void Add(string userId, int suggestionId)
        {
            var vote = this.votes.All().FirstOrDefault(x => x.AuthorId == userId && x.SuggestionId == suggestionId);
            if (vote == null)
            {
                vote = new Vote()
                {
                    AuthorId = userId,
                    SuggestionId = suggestionId,
                };
                this.votes.Add(vote);
                this.votes.Save();
            }
        }
    }
}
