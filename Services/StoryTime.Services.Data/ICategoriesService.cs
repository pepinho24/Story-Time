namespace StoryTime.Services.Data
{
    using System.Linq;

    using StoryTime.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
