using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YoutubeSubscriptionOrganizer.Core.Models;

namespace YoutubeSubscriptionOrganizer.Core.ViewModels
{
    public class HomePageViewModel
    {
        public List<ChannelGroup> ChannelGroups { get; set; }
        public List<YoutubeChannel> YoutubeChannels { get; set; }


    }
}