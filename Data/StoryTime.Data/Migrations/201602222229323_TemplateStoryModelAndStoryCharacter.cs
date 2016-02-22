namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemplateStoryModelAndStoryCharacter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoryCharacters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RepresentedBy = c.String(),
                        TemplateStoryId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TemplateStories", t => t.TemplateStoryId, cascadeDelete: true)
                .Index(t => t.TemplateStoryId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.TemplateStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Narrator = c.String(),
                        CharacterInTurn = c.String(),
                        IsStoryFinished = c.Boolean(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.StorySentences", "TemplateStory_Id", c => c.Int());
            CreateIndex("dbo.StorySentences", "TemplateStory_Id");
            AddForeignKey("dbo.StorySentences", "TemplateStory_Id", "dbo.TemplateStories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StorySentences", "TemplateStory_Id", "dbo.TemplateStories");
            DropForeignKey("dbo.StoryCharacters", "TemplateStoryId", "dbo.TemplateStories");
            DropIndex("dbo.TemplateStories", new[] { "IsDeleted" });
            DropIndex("dbo.StoryCharacters", new[] { "IsDeleted" });
            DropIndex("dbo.StoryCharacters", new[] { "TemplateStoryId" });
            DropIndex("dbo.StorySentences", new[] { "TemplateStory_Id" });
            DropColumn("dbo.StorySentences", "TemplateStory_Id");
            DropTable("dbo.TemplateStories");
            DropTable("dbo.StoryCharacters");
        }
    }
}
