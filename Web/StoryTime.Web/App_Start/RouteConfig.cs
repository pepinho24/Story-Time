namespace StoryTime.Web
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

          
            //routes.MapRoute(
            //    name: "TemplateStoryIndex",
            //    url: "TemplateStory/Index",
            //    defaults: new { area = string.Empty, controller = "TemplateStory", action = "Index" });

            //routes.MapRoute(
            // name: "TemplateStory",
            // url: "TemplateStory/{id}/{action}",
            // defaults: new { area = string.Empty, controller = "TemplateStory", action = "Configure" });

            //routes.MapRoute(
            // name: "Sentences",
            // url: "Stories/{id}/Sentences/{action}",
            // defaults: new { area = string.Empty, controller = "Sentences", action = "Index" });

            //routes.MapRoute(
            //  name: "StorySettings",
            //  url: "Stories/{id}/Settings/{action}",
            //  defaults: new { area = string.Empty, controller = "StorySettings", action = "Index" });

            routes.MapRoute(
                name: "JokePage",
                url: "Joke/{id}",
                defaults: new { area = string.Empty, controller = "Jokes", action = "ById" });
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{area}/{controller}/{action}/{id}",
            //    defaults: new { area = "Stories", controller = "Stories", action = "Index", id = UrlParameter.Optional, });

            routes.MapRoute(
                name: "Controller",
                url: "{controller}/{action}/{id}",
                defaults: new { area = string.Empty, controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "StoryTime.Web.Controllers" });

            //routes.MapRoute(
            //name: "admin",
            //url: "Administration/{controller}/{action}",
            //defaults: new { area = "Administration", controller = "Administration", action = "Index" });

        }
    }
}
