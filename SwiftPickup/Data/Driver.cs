using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftPickup.Data
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string VehicleType { get; set; }
        public string VehicleId { get; set; }
        public DateTime Created { get; set; }

        public ICollection<UserLocation> UserLocations { get; set; }
    }
}