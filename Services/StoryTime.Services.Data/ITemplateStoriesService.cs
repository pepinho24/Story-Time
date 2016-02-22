using StoryTime.Data.Models;
using System.Linq;

namespace StoryTime.Services.Data
{
    public interface ITemplateStoriesService
    {
        void AddSentence(int storyId, string content, string author);

        void AddCharacter(int storyId, string character, string author);

        void RemoveCharacter(int storyId, string character, string author);

        void AddWriterToCharacter(int storyId, string character, string writer, string author);

        void ChangeTurnToCharacter(int storyId, string character, string author);

        TemplateStory Create(string title, string creatorName);

        TemplateStory GetById(int id);

        IQueryable<TemplateStory> GetLatestStories(int count);

        void Finish(int storyId, string creator);
    }
}