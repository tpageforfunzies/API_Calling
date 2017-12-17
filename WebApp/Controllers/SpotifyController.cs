using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class SpotifyController : Controller
    {
        // GET: Spotify
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Auth()
        {
            return View();
        }
    }
}