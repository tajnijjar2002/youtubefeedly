using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using YoutubeSubscriptionOrganizer.Core.Models;
using YoutubeSubscriptionOrganizer.Core.ViewModels;
using YoutubeSubscriptionOrganizer.Models;

namespace YoutubeSubscriptionOrganizer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId ();
            var channelroups = _context.ChannelGroups
                .Where (c => c.UserId == userId)
                //.Include (c => c.YoutubeChannels)
                .ToList ();




            return View(channelroups);
        }

        [Authorize]
        public ActionResult ManageChannels ()
        {
            var userId = User.Identity.GetUserId();
            var allSubscriptions = _context.YoutubeChannels
                .Where(s => s.UserId == userId)
                .ToList();

            var channelGroups = _context.ChannelGroups
                .Where(c => c.UserId == userId)
                .Include(c => c.YoutubeChannels)
                .ToList();

            HomePageViewModel viewModel = new HomePageViewModel()
            {
                ChannelGroups = channelGroups,
                YoutubeChannels = allSubscriptions
            };

            if (allSubscriptions.Count != 0)
            {
                return View(viewModel);
            }



            return View();
        }


        


        [Authorize]
        public ActionResult UploadFile(HttpPostedFileBase xmlFile)
        {
            XMLFile file = new XMLFile();
            //This will upload the file.
            string filepath = file.UploadXmlFile(xmlFile);

            var userId = User.Identity.GetUserId ();
            //This will read the uploaded XML file and store all its records in the database.
            List<YoutubeChannel> youtubeChannels = file.ReadXmlFile(filepath, userId);

            var existingChannels = _context.YoutubeChannels
                                    .Select (c => c.Title)
                                    .ToList();


            foreach (var youtubeChannel in youtubeChannels)
            {
                var exists = existingChannels.Contains (youtubeChannel.Title);
                if (!exists)
                {
                    _context.YoutubeChannels.Add(youtubeChannel);
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}