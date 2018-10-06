using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IOC.Models
{
    public class LocationsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public LocationsModel(int pID, string pName, string pAddress, string pCity, string pState)
        {
            ID = pID;
            Name = pName;
            Address = pAddress;
            City = pCity;
            State = pState;
        }
    }
}