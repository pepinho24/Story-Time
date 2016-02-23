namespace StoryTime.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;

    using ViewModels.Home;
    using ViewModels.Stories;
    using ViewModels.TemplateStories;
    using System.Collections.Generic;

    public class HomeController : BaseController
    {
        private readonly IJokesService jokes;
        private readonly ICategoriesService jokeCategories;
        private readonly IStoriesService stories;
        private readonly ITemplateStoriesService templateStories;

        public HomeController(
            IJokesService jokes,
            IStoriesService stories,
            ITemplateStoriesService templateStories,
            ICategoriesService jokeCategories)
        {
            this.jokes = jokes;
            this.stories = stories;
            this.templateStories = templateStories;
            this.jokeCategories = jokeCategories;
        }

        public ActionResult Index()
        {
            var jokes = this.jokes.GetRandomJokes(3).To<JokeViewModel>().ToList();
            var categories =
                this.Cache.Get(
                    "categories",
                    () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
                    30 * 60);

            var st = this.stories.GetLatestStories(3).To<StoryViewModel>().ToList();
            var tempSt = this.templateStories.GetLatestStories(3).To<TemplateStoryViewModel>().ToList();
            var viewModel = new IndexViewModel
            {
                Jokes = jokes,
                Categories = categories,
                Stories = st,
                TemplateStories = tempSt
            };

            return this.View(viewModel);
        }
    }
}
