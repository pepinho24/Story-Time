namespace StoryTime.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStoryModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "WriterInTurn", c => c.Int(nullable: false));
            AddColumn("dbo.Stories", "IsStoryFinished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stories", "IsStoryFinished");
            DropColumn("dbo.Stories", "WriterInTurn");
        }
    }
}
