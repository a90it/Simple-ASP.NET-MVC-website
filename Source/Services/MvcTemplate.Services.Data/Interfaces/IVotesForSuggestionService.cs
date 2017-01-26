namespace MvcTemplate.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVotesForSuggestionService
    {
        void Add(string userId, int suggestionId);
    }
}
