using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YoutubeSubscriptionOrganizer.Core.Models;
using YoutubeSubscriptionOrganizer.Models;

namespace YoutubeSubscriptionOrganizer.Controllers.Api
{
    [Authorize]
    public class ChannelController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ChannelController ()
        {
            _context = new ApplicationDbContext ();
        }

        [HttpGet]
        public List<YoutubeChannel> GetChannelByChannelGroup (int groupId)
        {
            var channelsByGroup = _context.YoutubeChannels
                .Where (yc => yc.ChannelGroupId == groupId)
                .ToList ();


            return channelsByGroup;
        }

   
    }
}
