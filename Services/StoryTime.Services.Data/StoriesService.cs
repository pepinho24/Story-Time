namespace StoryTime.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StoryTime.Data.Common;
    using StoryTime.Data.Models;

    public class StoriesService : IStoriesService
    {
        private readonly IDbRepository<Story> stories;

        public StoriesService(IDbRepository<Story> stories)
        {
            this.stories = stories;
        }

        public Story GetById(int id)
        {
            var story = this.stories.GetById(id);
            return story;
        }

        public Story Create(string title)
        {
            var story = new Story() { Title = title };
            this.stories.Add(story);
            this.stories.Save();

            return story;
        }

        public StorySentence AddSentence(int storyId, string content, string author)
        {
            var sentence = new StorySentence() { Content = content, Author = author };
            var story = this.stories.GetById(storyId);

            story.Sentences.Add(sentence);
            this.stories.Save();

            return story.Sentences.LastOrDefault();
        }

        public IQueryable<Story> GetLatestStories(int count)
        {
            return this.stories.All().OrderBy(x => x.CreatedOn).Take(count);

            // return this.stories.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}
