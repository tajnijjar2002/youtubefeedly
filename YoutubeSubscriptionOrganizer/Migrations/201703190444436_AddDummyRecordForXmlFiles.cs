namespace YoutubeSubscriptionOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDummyRecordForXmlFiles : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO XMLFiles VALUES ('87747775-59c3-4f0c-9848-961001331f73','DummyFile','Dummy')");
        }
        
        public override void Down()
        {
        }
    }
}
