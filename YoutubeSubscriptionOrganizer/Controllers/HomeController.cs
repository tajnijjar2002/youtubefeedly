using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoutubeSubscriptionOrganizer.Core.Models;

namespace YoutubeSubscriptionOrganizer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            XMLFile file = new XMLFile();
            List<YoutubeChannel> youtubeChannels = file.ReadXmlFile();

            return View(youtubeChannels);
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