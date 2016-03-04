namespace StoryTime.Services.Data
{
    using System.Linq;
    using StoryTime.Data.Models;

    public interface IStoriesService
    {
        Story Create(string title, string plot, string creatorName);

        Story GetById(int id);

        IQueryable<Story> GetLatestStories(int count);
    }
}
