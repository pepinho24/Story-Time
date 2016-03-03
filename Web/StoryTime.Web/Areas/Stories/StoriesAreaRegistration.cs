namespace StoryTime.Web.Areas.Stories
{
    using System.Web.Mvc;

    public class StoriesAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Stories";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Stories_default",
                "Stories/{controller}/{action}/{id}",
                new { contorller = "Stories", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "StoryTime.Web.Areas.Stories.Controllers" }
            );
        }
    }
}
