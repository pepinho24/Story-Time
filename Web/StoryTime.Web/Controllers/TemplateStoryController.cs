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
        private readonly ITemplateStoriesService stories;

        public TemplateStoryController(ITemplateStoriesService stories)
        {
            this.stories = stories;
        }

        // GET: TemplateStory
        [Authorize]
        public ActionResult Configure(int id)
        {
            var story = this.stories.GetById(id);
            return this.View(story);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddCharacter(string id, string character)
        {
            var intId = int.Parse(id);
            this.stories.AddCharacter(intId, character, this.User.Identity.Name);

            return this.RedirectToAction("Configure", "TemplateStory", new { id = id });
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddWriterToCharacter(string id, string character, string writer)
        {
            var intId = int.Parse(id);
            this.stories.AddWriterToCharacter(intId, character, writer, this.User.Identity.Name);

            return this.RedirectToAction("Configure", "TemplateStory", new { id = id });
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoveCharacter(string id, string character)
        {
            var intId = int.Parse(id);
            this.stories.RemoveCharacter(intId, character, this.User.Identity.Name);

            return this.RedirectToAction("Configure", "TemplateStory", new { id = id });
        }

    }
}