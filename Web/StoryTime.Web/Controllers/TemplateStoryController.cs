namespace StoryTime.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using StoryTime.Services.Data;
    using ViewModels.TemplateStories;
    using Infrastructure.Mapping;
    public class TemplateStoryController : BaseController
    {
        private readonly ITemplateStoriesService stories;

        public TemplateStoryController(ITemplateStoriesService stories)
        {
            this.stories = stories;
        }
        
        public ActionResult Index()
        {
            var stories = this.stories.GetLatestStories(5).To<TemplateStoryViewModel>();
            return this.View(stories);
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

        [HttpPost]
        [Authorize]
        public ActionResult AddSentence(string id, string model)
        {
            var intId = int.Parse(id);
            this.stories.AddSentence(intId, model, this.User.Identity.Name);

            return this.RedirectToAction("Details", "TemplateStory", new { id = id });
        }

        public ActionResult Details(int id)
        {
            var story = this.stories.GetById(id);
            var viewModel = this.Mapper.Map<TemplateStoryViewModel>(story);
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangeTurn(int id, string character)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(character))
                {
                    this.stories.ChangeTurnToCharacter(id, character, this.User.Identity.Name);
                }

                return this.RedirectToAction("Details", "TemplateStory", new { id = id });
            }
            catch
            {
                return this.View();
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult FinishStory(int id)
        {
            try
            {
                this.stories.Finish(id, this.User.Identity.Name);
                return this.RedirectToAction("Details", "TemplateStory", new { id = id });
            }
            catch
            {
                return this.View();
            }
        }
    }
}