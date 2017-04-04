namespace YoutubeSubscriptionOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameAndPathPropertiesToXmlFile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.XMLFiles", "Name", c => c.String());
            AddColumn("dbo.XMLFiles", "Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.XMLFiles", "Path");
            DropColumn("dbo.XMLFiles", "Name");
        }
    }
}
