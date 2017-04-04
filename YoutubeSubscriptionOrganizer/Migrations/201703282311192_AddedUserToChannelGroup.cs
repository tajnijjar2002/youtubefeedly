namespace YoutubeSubscriptionOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserToChannelGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChannelGroups", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.ChannelGroups", "UserId");
            AddForeignKey("dbo.ChannelGroups", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChannelGroups", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.ChannelGroups", new[] { "UserId" });
            DropColumn("dbo.ChannelGroups", "UserId");
        }
    }
}
