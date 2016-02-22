namespace StoryTime.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using StoryTime.Services.Data;

    public class StorySettingsController : BaseController
    {
        private readonly IStoriesService stories;

        public StorySettingsController(IStoriesService stories)
        {
            this.stories = stories;
        }

        // GET: StorySettings
        public ActionResult Index(int id)
        {
            var story = this.stories.GetById(id);
            return this.View(story);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddWriter(string id, string model)
        {
            var intId = int.Parse(id);
            this.stories.AddWriter(intId, model, this.User.Identity.Name);

            return this.RedirectToAction("Index", "StorySettings", new { id = id });
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoveWriter(string id, string writer)
        {
            var intId = int.Parse(id);
            this.stories.RemoveWriter(intId, writer, this.User.Identity.Name);

            return this.RedirectToAction("Index", "StorySettings", new { id = id });
        }
    }
}
