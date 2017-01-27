﻿namespace MvcTemplate.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using MvcTemplate.Services.Data;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using ViewModels.Suggestions;

    public class SuggestionsController : BaseController
    {
        private readonly ISuggestionService suggestions;

        public SuggestionsController(ISuggestionService suggestions)
        {
            this.suggestions = suggestions;
        }

        public ActionResult All()
        {
            var suggestions = this.suggestions.GetAll().To<SuggestionViewModel>().ToList();
            return this.View(suggestions);
        }

        public ActionResult ById(string id)
        {
            var suggestionTemp = this.suggestions.GetById(id);
            var suggestion = this.Mapper.Map<SuggestionViewModel>(suggestionTemp);
            var userId = this.User.Identity.GetUserId();
            bool currentUserHasVoted = this.suggestions.CurrentUserHasVoted(userId, id);
            var viewModel = new SuggestionWithVotingStatsViewModel { Suggestion = suggestion, CurrentUserHasVoted = currentUserHasVoted };
            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult AddSuggestion()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddSuggestion(SuggestionViewModel viewModel)
        {
            var suggestion = new Suggestion();

            // TODO: use automapper for mapping instead
            suggestion.AuthorId = this.User.Identity.GetUserId();
            suggestion.Title = viewModel.Title;
            suggestion.Content = viewModel.Content;

            this.suggestions.Create(suggestion);
            return this.Redirect("/Suggestions/All");
        }

        // TODO: HttpDelete
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public ActionResult DeleteSuggestion(int id)
        {
            this.suggestions.DeleteById(id);
            return this.Redirect("/Suggestions/All");
        }
    }
}