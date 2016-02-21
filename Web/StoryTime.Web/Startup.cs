using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(StoryTime.Web.Startup))]

namespace StoryTime.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
