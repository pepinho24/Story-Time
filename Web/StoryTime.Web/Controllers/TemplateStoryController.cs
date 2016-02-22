namespace StoryTime.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using StoryTime.Services.Data;

    public class TemplateStoryController : BaseController
    {
        private readonly IStoriesService stories;

        public TemplateStoryController(IStoriesService stories)
        {
            this.stories = stories;
        }

        // GET: TemplateStory
        public ActionResult Configure(int id)
        {
            return View();
        }
    }
}