namespace StoryTime.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using StoryTime.Services.Data;
    using StoryTime.Web.ViewModels.Stories;
    using StoryTime.Web.Infrastructure.Mapping;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    public class StoriesController : BaseController
    {
        private readonly IStoriesService stories;

        public StoriesController(IStoriesService stories)
        {
            this.stories = stories;
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

        // GET: Stories/Delete/5
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: Stories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return this.RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }
    }
}
