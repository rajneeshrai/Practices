using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieReviewApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return Redirect("http://localhost:50098/");
            //return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return RedirectToRoute(new { action = "about" });
            //return View();
        }
    }
}