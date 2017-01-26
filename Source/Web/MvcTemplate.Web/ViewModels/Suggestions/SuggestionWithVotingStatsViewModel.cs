namespace MvcTemplate.Web.ViewModels.Suggestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using MvcTemplate.Web.ViewModels.Suggestions;

    public class SuggestionWithVotingStatsViewModel
    {
        public SuggestionViewModel Suggestion { get; set; }

        public bool CurrentUserHasVoted { get; set; }
    }
}
