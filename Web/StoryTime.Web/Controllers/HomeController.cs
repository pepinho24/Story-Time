namespace StoryTime.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using ViewModels.Home;
    using ViewModels.Stories;
    using ViewModels.TemplateStories;
    using System.Collections.Generic;
    using Services.Data;

    public class HomeController : BaseController
    {
        private readonly IUsersService users;
        private readonly IStoriesService stories;

        public HomeController(IUsersService users, IStoriesService stories)
        {
            this.users = users;
            this.stories = stories;
        }

        public ActionResult Index()
        {
            var users = this.users.GetAll().ToList();

            return this.View(users);
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreateStory()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateStory(StoryInputModel model)
        {
            var storyId = this.stories.Create(model.Title, model.Plot, this.User.Identity.Name).Id;
            return this.RedirectToAction("Index", "Home");
        }
        //public HomeController(
        //    IJokesService jokes,
        //    IStoriesService stories,
        //    ITemplateStoriesService templateStories,
        //    ICategoriesService jokeCategories)
        //{
        //    this.jokes = jokes;
        //    this.stories = stories;
        //    this.templateStories = templateStories;
        //    this.jokeCategories = jokeCategories;
        //}

        //public ActionResult Index()
        //{
        //    var jokes = this.jokes.GetRandomJokes(3).To<JokeViewModel>().ToList();
        //    var categories =
        //        this.Cache.Get(
        //            "categories",
        //            () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
        //            30 * 60);

        //    var st = this.stories.GetLatestStories(3).To<StoryViewModel>().ToList();
        //    var tempSt = this.templateStories.GetLatestStories(3).To<TemplateStoryViewModel>().ToList();
        //    var viewModel = new IndexViewModel
        //    {
        //        Jokes = jokes,
        //        Categories = categories,
        //        Stories = st,
        //        TemplateStories = tempSt
        //    };

        //    return this.View(viewModel);
        //}
    }
}
