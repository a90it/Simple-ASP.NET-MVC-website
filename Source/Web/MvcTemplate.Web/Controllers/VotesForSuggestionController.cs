namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using Services.Web;

    [Authorize]
    public class VotesForSuggestionController : BaseController
    {
        private readonly IVotesForSuggestionService votes;
        private readonly IIdentifierProvider identifierProvider;

        public VotesForSuggestionController(IVotesForSuggestionService votes, IIdentifierProvider identifierProvider)
        {
            this.votes = votes;
            this.identifierProvider = identifierProvider;
        }

        [HttpPost]
        public void Vote(int suggestionId)
        {
            var userId = this.User.Identity.GetUserId();
            this.votes.Add(userId, suggestionId);
        }
    }
}
