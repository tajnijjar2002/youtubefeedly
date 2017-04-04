using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSubscriptionOrganizer.Models;

namespace YoutubeSubscriptionOrganizer.Core.Models
{
    public class ChannelGroup
    {
        public int Id { get; set; }
        public string ChannelGroupName { get; set; }
        public List<YoutubeChannel> YoutubeChannels { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

    }
}