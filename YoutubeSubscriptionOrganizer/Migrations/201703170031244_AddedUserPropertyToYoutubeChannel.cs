namespace YoutubeSubscriptionOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserPropertyToYoutubeChannel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.YoutubeChannels", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.YoutubeChannels", "UserId");
            AddForeignKey("dbo.YoutubeChannels", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YoutubeChannels", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.YoutubeChannels", new[] { "UserId" });
            DropColumn("dbo.YoutubeChannels", "UserId");
        }
    }
}
