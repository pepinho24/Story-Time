namespace StoryTime.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    using StoryTime.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Joke> Jokes { get; set; }

        public IDbSet<JokeCategory> JokesCategories { get; set; }

        public IDbSet<Story> Stories { get; set; }

        public IDbSet<StorySentence> StorySentences { get; set; }

        public IDbSet<TemplateStorySentence> TemplateStorySentences { get; set; }

        public IDbSet<StoryWriter> StoryWriters { get; set; }

        public IDbSet<TemplateStory> TemplateStories { get; set; }

        public IDbSet<StoryCharacter> StoryCharacters { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }                
    }
}
