namespace StoryTime.Web.Areas.Stories.Controllers
{
    using System.Web.Mvc;
    using StoryTime.Services.Data;
    using Web.Controllers;

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