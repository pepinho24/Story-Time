namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemplateStoryAndSentenceModel : DbMigration
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
            
            CreateTable(
                "dbo.TemplateStorySentences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Author = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemplateStorySentences", "TemplateStoryId", "dbo.TemplateStories");
            DropForeignKey("dbo.StoryCharacters", "TemplateStoryId", "dbo.TemplateStories");
            DropIndex("dbo.TemplateStorySentences", new[] { "IsDeleted" });
            DropIndex("dbo.TemplateStorySentences", new[] { "TemplateStoryId" });
            DropIndex("dbo.TemplateStories", new[] { "IsDeleted" });
            DropIndex("dbo.StoryCharacters", new[] { "IsDeleted" });
            DropIndex("dbo.StoryCharacters", new[] { "TemplateStoryId" });
            DropTable("dbo.TemplateStorySentences");
            DropTable("dbo.TemplateStories");
            DropTable("dbo.StoryCharacters");
        }
    }
}
