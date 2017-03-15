using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace YoutubeSubscriptionOrganizer.Core.Models
{
    public class XMLFile
    {
        public int Id { get; set; }
        public List<YoutubeChannel> YoutubeChannels { get; set; }

        public XMLFile()
        {
            YoutubeChannels = new List<YoutubeChannel>();
        }

        public List<YoutubeChannel> ReadXmlFile()
        {
            XmlReader reader =
                XmlReader.Create(
                    "E:\\PRACTICE\\PORJECTS\\YoutubeSubscriptionOrganizer\\YoutubeSubscriptionOrganizer\\YoutubeSubscriptionOrganizer\\subscription_manager.xml");

            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "outline" && reader.GetAttribute("title") != "YouTube Subscriptions")
                {
                    YoutubeChannel channel = new YoutubeChannel();

                    channel.Id = 1;
                    channel.Title = reader.GetAttribute ("title");
                    channel.XmlUrl = reader.GetAttribute ("xmlUrl");
                    channel.ChannelUrl = channel.SetChannelUrl ();
                    

                    this.YoutubeChannels.Add(channel);
                }
            }

            return YoutubeChannels;
        }

    }

   
}