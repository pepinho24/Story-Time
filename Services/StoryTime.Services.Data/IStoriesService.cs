namespace StoryTime.Services.Data
{
    using System.Linq;
    using StoryTime.Data.Models;

    public interface IStoriesService
    {
        StorySentence AddSentence(int storyId, string content, string author);

        Story Create(string Title);

        Story GetById(int id);

        IQueryable<Story> GetLatestStories(int count);
    }
}