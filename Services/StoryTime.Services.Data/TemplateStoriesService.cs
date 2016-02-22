namespace StoryTime.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using StoryTime.Data.Common;
    using StoryTime.Data.Models;

    public class TemplateStoriesService : ITemplateStoriesService
    {
        private readonly IDbRepository<TemplateStory> templateStories;
        private readonly IDbRepository<StoryCharacter> characters;

        public TemplateStoriesService(IDbRepository<TemplateStory> templateStories, IDbRepository<StoryCharacter> characters)
        {
            this.templateStories = templateStories;
            this.characters = characters;
        }

        public void AddSentence(int storyId, string content, string author)
        {
            var story = this.templateStories.GetById(storyId);
            if (story.CharacterInTurn != author)
            {
                return;
            }

            var sentence = new StorySentence() { Content = content, Author = author };

            story.Sentences.Add(sentence);
            story.CharacterInTurn = "Narrator";
            this.templateStories.Save();
        }

        public void AddCharacter(int storyId, string character, string author)
        {
            var story = this.templateStories.GetById(storyId);
            if (story.Narrator != author)
            {
                return;
            }

            story.Characters.Add(new StoryCharacter() { Name = character });
            this.templateStories.Save();
        }

        public void RemoveCharacter(int storyId, string character, string author)
        {
            var story = this.templateStories.GetById(storyId);
            if (story.Narrator != author)
            {
                return;
            }

            story.Characters.Remove(story.Characters.FirstOrDefault(c => c.Name == character));
            this.templateStories.Save();
        }

        public void AddWriterToCharacter(int storyId, string character, string writer, string author)
        {
            var story = this.templateStories.GetById(storyId);
            if (story.Narrator != author)
            {
                return;
            }

            var dbCharacter = story.Characters.FirstOrDefault(c => c.Name == character);
            dbCharacter.RepresentedBy = writer;
            this.templateStories.Save();
        }

        public void ChangeTurnToCharacter(int storyId, string character, string author)
        {
            var story = this.templateStories.GetById(storyId);
            if (story.Narrator != author)
            {
                return;
            }

            var narrator = story.Characters.FirstOrDefault(c => c.Name == character);
            if (narrator == null)
            {
                narrator = story.Characters.FirstOrDefault(c => c.Name == "Narrator");
            }

            story.CharacterInTurn = narrator.Name;
            this.templateStories.Save();
        }

        public TemplateStory Create(string title, string creatorName)
        {
            var story = new TemplateStory()
            {
                Title = title,
                Narrator = creatorName,
                IsStoryFinished = false
            };

            this.templateStories.Add(story);
            this.templateStories.Save();
            this.AddCharacter(story.Id, "Narrator", creatorName);
            this.AddWriterToCharacter(story.Id, "Narrator", creatorName, creatorName);
            this.ChangeTurnToCharacter(story.Id, "Narrator", creatorName);

            return story;
        }

        public TemplateStory GetById(int id)
        {
            return this.templateStories.GetById(id);
        }

        public IQueryable<TemplateStory> GetLatestStories(int count)
        {
            return this.templateStories.All().Take(count);
        }

        public void Finish(int storyId, string creator)
        {
            var story = this.templateStories.GetById(storyId);
            if (story.Narrator != creator)
            {
                return;
            }

            story.IsStoryFinished = true;
        }
    }
}
