﻿namespace StoryTime.Services.Data
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
        private readonly IDbRepository<StoryWriter> writers;

        public StoriesService(IDbRepository<Story> stories, IDbRepository<StoryWriter> writers)
        {
            this.stories = stories;
            this.writers = writers;
        }

        public Story GetById(int id)
        {
            var story = this.stories.GetById(id);
            return story;
        }

        public Story Create(string title, string creatorName)
        {
            var creator = new StoryWriter() { Name = creatorName };
            var story = new Story()
            {
                Title = title,
                Creator = creatorName,
                IsStoryFinished = false,
                WriterInTurn = 0
            };
            story.Writers.Add(creator);

            this.stories.Add(story);
            this.stories.Save();

            return story;
        }

        public void AddSentence(int storyId, string content, string author)
        {
            var story = this.stories.GetById(storyId);
            story.WriterInTurn = story.WriterInTurn >= story.Writers.Count ? 0 : story.WriterInTurn;
            var wrInTurn = story.Writers.ElementAtOrDefault(story.WriterInTurn);

            if (wrInTurn == null || wrInTurn.Name != author)
            {
                return;
            }

            var sentence = new StorySentence() { Content = content, Author = author };

            story.Sentences.Add(sentence);
            story.WriterInTurn++;
            this.stories.Save();
        }

        public IQueryable<Story> GetLatestStories(int count)
        {
            return this.stories.All().OrderBy(x => x.CreatedOn).Take(count);

            // return this.stories.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }

        public void AddWriter(int storyId, string writer, string author)
        {
            // TODO: Validation, does the writer exist
            var story = this.stories.GetById(storyId);
            if (story.Creator != author)
            {
                return;
            }

            var writerEntity = new StoryWriter() { Name = writer };
            story.Writers.Add(writerEntity);
            this.stories.Save();
        }

        public void RemoveWriter(int storyId, string writer, string author)
        {
            // TODO: Validation, does the writer exist
            var story = this.stories.GetById(storyId);
            if (story.Creator != author)
            {
                return;
            }

            var wr = this.writers.All().Where(w => w.Name == writer && w.StoryId == storyId).FirstOrDefault();
            if (wr != null)
            {
                this.writers.HardDelete(wr);
                this.writers.Save();
            }
        }

        public void Finish(int storyId, string creator)
        {
            var story = this.stories.GetById(storyId);
            if (story.Creator != creator)
            {
                return;
            }

            story.IsStoryFinished = true;
            this.stories.Save();
        }
    }
}
