using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml;
using YoutubeSubscriptionOrganizer.Models;

namespace YoutubeSubscriptionOrganizer.Core.Models
{
    public class XMLFile
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Path { get; set; }

        public List<YoutubeChannel> YoutubeChannels { get; set; }


        public ApplicationUser User { get; set; }
        public string UserId { get; set; }


        public XMLFile()
        {
            YoutubeChannels = new List<YoutubeChannel>();
        }

        //Accepts a file and the userId.
        //Returns a list of YoutubeChannels assisiating every record with the userId
        public List<YoutubeChannel> ReadXmlFile(string filePath, string userId)
        {
            //FileStream stream = new FileStream(@"myfile.xml", FileMode.Open,
            //                FileAccess.Read, FileShare.ReadWrite);
            XmlReader reader =
                XmlReader.Create(filePath);

            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "outline" && reader.GetAttribute("title") != "YouTube Subscriptions")
                {
                    YoutubeChannel channel = new YoutubeChannel();

                    //channel.Id = 1;
                    channel.UserId = userId;
                    channel.Title = reader.GetAttribute ("title");
                    channel.XmlUrl = reader.GetAttribute ("xmlUrl");
                    channel.ChannelUrl = channel.SetChannelUrl ();
                    channel.ChannelGroupId = 1;
                    channel.XmlFileId = 1;

                    this.YoutubeChannels.Add(channel);
                }
            }

            

            //if (File.Exists (filePath))
            //{
            //    File.Delete (filePath);
            //}

            return YoutubeChannels;
        }

        public string UploadXmlFile (HttpPostedFileBase xmlFile)
        {

            //Adding UploadedImage record
            //The image is saved with a file name as guid.
            var path = HostingEnvironment.MapPath("~/Files");
            var name = xmlFile.FileName;

            var customName = path + "\\" + name;



            xmlFile.SaveAs(customName);

            return customName;
            //following is done to get the height and width of the image.
            //Image image = Image.FromFile(finalPath);


        }

    }

   
}