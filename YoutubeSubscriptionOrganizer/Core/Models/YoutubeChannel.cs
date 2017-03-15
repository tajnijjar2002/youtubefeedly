using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YoutubeSubscriptionOrganizer.Core.Models
{
    public class YoutubeChannel
    {
        public YoutubeChannel ()
        {
            
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string XmlUrl { get; set; }

        private string _channelUrl;

        public string ChannelUrl
        {
            get
            {
                return _channelUrl; 
                
            }
            set
            {
                _channelUrl = SetChannelUrl();
            }
        }


        //public string ChannelUrl
        //{
        //    get; private set;
        //}


        public string SetChannelUrl()
        {
            //https://www.youtube.com/feeds/videos.xml?channel_id=UCsbfPM5Wd1REwCIBYJFIyOw

            int indexOfChannelId = XmlUrl.IndexOf ("channel_id");
            int lengthOfChannelId = "channel_id=".Length;
            int subStringStart = indexOfChannelId + lengthOfChannelId;
            int subStringLength = XmlUrl.Length - subStringStart;
            string channelUrl = XmlUrl.Substring (subStringStart, subStringLength);

            return channelUrl;
        }
    }
}