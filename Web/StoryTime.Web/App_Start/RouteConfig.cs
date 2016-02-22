namespace StoryTime.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "TemplateStory",
             url: "TemplateStory/{id}/{action}",
             defaults: new { controller = "TemplateStory", action = "Configure" });

            routes.MapRoute(
             name: "Sentences",
             url: "Stories/{id}/Sentences/{action}",
             defaults: new { controller = "Sentences", action = "Index" });

            routes.MapRoute(
              name: "StorySettings",
              url: "Stories/{id}/Settings/{action}",
              defaults: new { controller = "StorySettings", action = "Index" });

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
