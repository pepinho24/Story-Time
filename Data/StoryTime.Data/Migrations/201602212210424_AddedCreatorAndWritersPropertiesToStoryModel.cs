namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreatorAndWritersPropertiesToStoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoryWriters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .Index(t => t.StoryId);
            
            AddColumn("dbo.Stories", "Creator", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoryWriters", "StoryId", "dbo.Stories");
            DropIndex("dbo.StoryWriters", new[] { "StoryId" });
            DropColumn("dbo.Stories", "Creator");
            DropTable("dbo.StoryWriters");
        }
    }
}
