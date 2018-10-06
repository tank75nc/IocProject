using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "IOC Demo Application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "James Lentz";

            return View();
        }
    }
}