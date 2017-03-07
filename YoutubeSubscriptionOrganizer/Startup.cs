using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YoutubeSubscriptionOrganizer.Startup))]
namespace YoutubeSubscriptionOrganizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
