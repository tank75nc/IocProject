using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        public ActionResult Index()
        {
            List<Models.LocationsModel> locations = new List<Models.LocationsModel>();
            locations.Add(new Models.LocationsModel(1, "Pinkerton", "5466 Gordon Ave", "Charlotte", "North Carolina"));
            locations.Add(new Models.LocationsModel(5, "East Lansing", "123 This Street", "Lansing", "Michigan"));
            locations.Add(new Models.LocationsModel(6, "Johnson #3", "", "Gallatin", "Missouri"));
            locations.Add(new Models.LocationsModel(11, "Everette and Smithey", "18221 W Marshal Blvd", "Oakland", "California"));

            return View(locations);
        }
    }
}