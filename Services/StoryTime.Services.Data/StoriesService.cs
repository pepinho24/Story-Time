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
        private readonly IUsersService users;

        public StoriesService(IDbRepository<Story> stories, IUsersService users)
        {
            this.stories = stories;
            this.users = users;
        }

        public Story GetById(int id)
        {
            var story = this.stories.GetById(id);
            return story;
        }

        public Story Create(string title, string plot,  string creatorName)
        {
            var user = this.users.GetAll().FirstOrDefault(u => u.UserName == creatorName);

            var story = new Story()
            {
                Plot = plot,
                Title = title,
                User = user
            };

            this.stories.Add(story);
            this.stories.Save();

            return story;
        }

        public IQueryable<Story> GetLatestStories(int count)
        {
            return this.stories.All().OrderBy(x => x.CreatedOn).Take(count);

            // return this.stories.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}
