using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using YoutubeSubscriptionOrganizer.Core;
using YoutubeSubscriptionOrganizer.Core.Models;
using YoutubeSubscriptionOrganizer.Core.ViewModels;
using YoutubeSubscriptionOrganizer.Models;

namespace YoutubeSubscriptionOrganizer.Controllers.Api
{
    [Authorize]
    public class UpdateChannelGroupController : ApiController
    {
        private ApplicationDbContext _context;

        public UpdateChannelGroupController ()
        {
            _context = new ApplicationDbContext ();
        }


        [HttpPost]
        public ChannelGroup CreateNewChannelGroup (CreateNewChannelGroupViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException (HttpStatusCode.BadRequest);
            }

            var userId = User.Identity.GetUserId ();
            ChannelGroup channelGroup = new ChannelGroup()
            {
                ChannelGroupName = viewModel.ChannelGroupName,
                UserId = userId
            };

            _context.ChannelGroups.Add(channelGroup);
            _context.SaveChanges ();

            return channelGroup;
        }


        [HttpPut]
        public IHttpActionResult UpdateYoutubeChannelGroup (UpdateYoutubeChannelGroupViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var youtubeChannel = _context.YoutubeChannels
                .Single(y => y.Id == viewModel.YoutubeChannelId);


            var channelGroup = _context.ChannelGroups
                .Single(y => y.ChannelGroupName == viewModel.ChannelGroupName)
                ;

            var channelGroupId = channelGroup.Id;

            //youtubeChannel.ChannelGroupId = viewModel.ChannelGroupId;
            youtubeChannel.ChannelGroupId = channelGroupId;

            _context.SaveChanges();

            return Ok();
        }

    }
}
