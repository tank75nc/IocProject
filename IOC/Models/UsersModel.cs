using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace IOC.Models
{
    public class UsersModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public UsersModel(string pFirstName, string pLastName, string pUserName, string pCity, string pState)
        {
            FirstName = pFirstName;
            LastName = pLastName;
            UserName = pUserName;
            City = pCity;
            State = pState;
        }
    }
}