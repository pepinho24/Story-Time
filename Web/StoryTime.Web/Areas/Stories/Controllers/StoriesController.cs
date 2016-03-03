namespace StoryTime.Web.Areas.Stories.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using StoryTime.Services.Data;
    using StoryTime.Web.ViewModels.Stories;
    using StoryTime.Web.Infrastructure.Mapping;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using Web.Controllers;
    public class StoriesController : BaseController
    {
        private readonly IStoriesService stories;
        private readonly ITemplateStoriesService templateStories;

        public StoriesController(IStoriesService stories, ITemplateStoriesService templateStories)
        {
            this.stories = stories;
            this.templateStories = templateStories;
        }

        // GET: Stories
        public ActionResult Index()
        {
            var stories = this.stories.GetLatestStories(10);
            var viewModel = this.Mapper.Map<ICollection<StoryViewModel>>(stories);
            //.To<ICollection<StoryViewModel>>()
            //.ToList();
            return this.View(viewModel);
        }

        // GET: Stories/Details/5
        public ActionResult Details(int id)
        {
            var story = this.stories.GetById(id);
            var viewModel = this.Mapper.Map<StoryViewModel>(story);
            return this.View(viewModel);
        }

        // GET: Stories/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Stories/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(StoryInputModel model)
        {
            if (model.Type == "Normal")
            {
                try
                {
                    var storyId = this.stories.Create(model.Title, this.User.Identity.Name).Id;
                    return this.RedirectToAction("Index", "StorySettings", new { id = storyId });
                }
                catch
                {
                    return this.View();
                }
            }
            else
            {
                try
                {
                    var storyId = this.templateStories.Create(model.Title, this.User.Identity.Name).Id;
                    return this.RedirectToAction("Configure", "TemplateStory", new { id = storyId });
                }
                catch (System.Exception ex)
                {
                    return this.View();
                }
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult FinishStory(int id)
        {
            try
            {
                this.stories.Finish(id, this.User.Identity.Name);
                return this.RedirectToAction("Details", "Stories", new { id = id });
            }
            catch
            {
                return this.View();
            }
        }
    }
}
