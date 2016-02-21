namespace StoryTime.Services.Data
{
    using System.Linq;
    using StoryTime.Data.Models;

    public interface IStoriesService
    {
        StorySentence AddSentence(int storyId, string content, string author);

        void AddWriter(int storyId, string writer, string author);

        Story Create(string title, string creatorName);

        Story GetById(int id);

        IQueryable<Story> GetLatestStories(int count);
    }
}