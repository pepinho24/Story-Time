namespace StoryTime.Web.ViewModels.Home
{
    using Stories;
    using System.Collections.Generic;
    using TemplateStories;

    public class IndexViewModel
    {
        public IEnumerable<JokeViewModel> Jokes { get; set; }

        public IEnumerable<JokeCategoryViewModel> Categories { get; set; }

        public IEnumerable<StoryViewModel> Stories { get; set; }

        public IEnumerable<TemplateStoryViewModel> TemplateStories { get; set; }

    }
}
