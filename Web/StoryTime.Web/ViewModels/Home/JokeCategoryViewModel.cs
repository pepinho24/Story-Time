namespace StoryTime.Web.ViewModels.Home
{
    using StoryTime.Data.Models;
    using StoryTime.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
