using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftPickup.Data
{
    public class Pickup
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string TripId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Initial { get; set; }
        public string Phone { get; set; }
        public string Medicaid { get; set; }
        public string Plus { get; set; }
        public string Vehicle { get; set; }
        public string ServiceLevel { get; set; }
        public string ApptDate { get; set; }
        public string Crutches { get; set; }
        public string SpecialNeeds { get; set; }
        public string TripType { get; set; }
        public int Age { get; set; }
        public int CarSeats { get; set; }
        public int ApptHour { get; set; }
        public int ApptMin { get; set; }
        public int ReturnHour { get; set; }
        public int ReturnMin { get; set; }
        public string ReturnLocation { get; set; }
        public string DeliverAddress { get; set; }
        public string DeliverAddress2 { get; set; }
        public string DeliverCity { get; set; }
        public string DeliverState { get; set; }
        public string DeliverZip { get; set; }
        public string DeliverPhone { get; set; }
        public DateTime Created { get; set; }
    }
}
