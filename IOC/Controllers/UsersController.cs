using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IOC.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListUsers()
        {
            List<Models.UsersModel> users = new List<Models.UsersModel>();
            
            users.Add(new Models.UsersModel("James", "Lentz", "jlentz", "Layton", "Utah"));
            users.Add(new Models.UsersModel("Jeff", "Shumway", "jshumway", "Dallas", "Texas"));
            users.Add(new Models.UsersModel("Alison", "Smith", "asmith", "Chicago", "Illinois"));
            users.Add(new Models.UsersModel("Michael", "Washington", "mwashington", "Greensboro", "North Carolina"));
            users.Add(new Models.UsersModel("Peter", "Hannibal", "phannibal", "Rockport", "Maine"));

            return View(users);
        }
    }
}