namespace YoutubeSubscriptionOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedXmlFileAndYoutubeChannelModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.XMLFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.YoutubeChannels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        XmlUrl = c.String(),
                        ChannelUrl = c.String(),
                        XMLFile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.XMLFiles", t => t.XMLFile_Id)
                .Index(t => t.XMLFile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YoutubeChannels", "XMLFile_Id", "dbo.XMLFiles");
            DropIndex("dbo.YoutubeChannels", new[] { "XMLFile_Id" });
            DropTable("dbo.YoutubeChannels");
            DropTable("dbo.XMLFiles");
        }
    }
}
