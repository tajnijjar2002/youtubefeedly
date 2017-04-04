namespace YoutubeSubscriptionOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserPropertyToXmlFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.XMLFiles", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.XMLFiles", "UserId");
            AddForeignKey("dbo.XMLFiles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.XMLFiles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.XMLFiles", new[] { "UserId" });
            DropColumn("dbo.XMLFiles", "UserId");
        }
    }
}
