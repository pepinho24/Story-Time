namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStoryWriterModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoryWriters", "CreatedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.StoryWriters", "ModifiedOn", c => c.DateTime());
            AddColumn("dbo.StoryWriters", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.StoryWriters", "DeletedOn", c => c.DateTime());
            CreateIndex("dbo.StoryWriters", "IsDeleted");
        }
        
        public override void Down()
        {
            DropIndex("dbo.StoryWriters", new[] { "IsDeleted" });
            DropColumn("dbo.StoryWriters", "DeletedOn");
            DropColumn("dbo.StoryWriters", "IsDeleted");
            DropColumn("dbo.StoryWriters", "ModifiedOn");
            DropColumn("dbo.StoryWriters", "CreatedOn");
        }
    }
}
