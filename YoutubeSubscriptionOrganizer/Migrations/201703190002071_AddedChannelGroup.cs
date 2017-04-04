namespace YoutubeSubscriptionOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedChannelGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.YoutubeChannels", "XMLFile_Id", "dbo.XMLFiles");
            DropIndex("dbo.YoutubeChannels", new[] { "XMLFile_Id" });
            RenameColumn(table: "dbo.YoutubeChannels", name: "XMLFile_Id", newName: "XmlFileId");
            CreateTable(
                "dbo.ChannelGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChannelGroupName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.YoutubeChannels", "ChannelGroupId", c => c.Int(nullable: false));
            AlterColumn("dbo.YoutubeChannels", "XmlFileId", c => c.Int(nullable: false));
            CreateIndex("dbo.YoutubeChannels", "XmlFileId");
            CreateIndex("dbo.YoutubeChannels", "ChannelGroupId");
            AddForeignKey("dbo.YoutubeChannels", "ChannelGroupId", "dbo.ChannelGroups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.YoutubeChannels", "XmlFileId", "dbo.XMLFiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YoutubeChannels", "XmlFileId", "dbo.XMLFiles");
            DropForeignKey("dbo.YoutubeChannels", "ChannelGroupId", "dbo.ChannelGroups");
            DropIndex("dbo.YoutubeChannels", new[] { "ChannelGroupId" });
            DropIndex("dbo.YoutubeChannels", new[] { "XmlFileId" });
            AlterColumn("dbo.YoutubeChannels", "XmlFileId", c => c.Int());
            DropColumn("dbo.YoutubeChannels", "ChannelGroupId");
            DropTable("dbo.ChannelGroups");
            RenameColumn(table: "dbo.YoutubeChannels", name: "XmlFileId", newName: "XMLFile_Id");
            CreateIndex("dbo.YoutubeChannels", "XMLFile_Id");
            AddForeignKey("dbo.YoutubeChannels", "XMLFile_Id", "dbo.XMLFiles", "Id");
        }
    }
}
