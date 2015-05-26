using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SwiftPickup.Data
{
    public class UserLocation
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public int DriverId { get; set; }
    }
}
