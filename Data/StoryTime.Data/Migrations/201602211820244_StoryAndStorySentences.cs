namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoryAndStorySentences : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.StorySentences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Author = c.String(),
                        StoryId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .Index(t => t.StoryId)
                .Index(t => t.IsDeleted);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StorySentences", "StoryId", "dbo.Stories");
            DropIndex("dbo.StorySentences", new[] { "IsDeleted" });
            DropIndex("dbo.StorySentences", new[] { "StoryId" });
            DropIndex("dbo.Stories", new[] { "IsDeleted" });
            DropTable("dbo.StorySentences");
            DropTable("dbo.Stories");
        }
    }
}
