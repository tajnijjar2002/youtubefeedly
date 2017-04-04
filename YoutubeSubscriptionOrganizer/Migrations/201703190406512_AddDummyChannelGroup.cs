namespace YoutubeSubscriptionOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDummyChannelGroup : DbMigration
    {
        public override void Up()
        {
            Sql ("INSERT INTO ChannelGroups VALUES ('None')");
        }
        
        public override void Down()
        {
        }
    }
}
