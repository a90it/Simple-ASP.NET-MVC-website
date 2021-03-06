﻿namespace MvcTemplate.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "PostPage",
              url: "Post/{id}",
              defaults: new { controller = "Posts", action = "ById" });
            routes.MapRoute(
               name: "SuggestionPage",
               url: "Suggestion/{id}",
               defaults: new { controller = "Suggestions", action = "ById" });
            routes.MapRoute(
                name: "CategoryPage",
                url: "Category/{id}",
                defaults: new { controller = "Jokes", action = "Category" });
            routes.MapRoute(
                name: "JokePage",
                url: "Joke/{id}",
                defaults: new { controller = "Jokes", action = "ById" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
