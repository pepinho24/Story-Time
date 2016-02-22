namespace StoryTime.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using StoryTime.Services.Data;

    public class SentencesController : BaseController
    {
        private readonly IStoriesService stories;

        public SentencesController(IStoriesService stories)
        {
            this.stories = stories;
        }

        // TODO: make it ajax
        // POST: Stories/Details/5
        [HttpPost]
        [Authorize]
        public ActionResult Add(string id, string model)
        {
            var intId = int.Parse(id);
            this.stories.AddSentence(intId, model, this.User.Identity.Name);

            return this.RedirectToAction("Details", "Stories", new { id = id });
        }
    }
}