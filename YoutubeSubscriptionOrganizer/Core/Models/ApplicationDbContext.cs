using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using YoutubeSubscriptionOrganizer.Core.Models;

namespace YoutubeSubscriptionOrganizer.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<YoutubeChannel> YoutubeChannels { get; set; }
        public DbSet<XMLFile> XmlFiles { get; set; }







        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}