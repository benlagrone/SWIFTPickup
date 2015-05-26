using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SwiftPickup.Data;

namespace SwiftPickup.Controllers
{
    public class PickupsController : ApiController
    {

        private ISwiftPickupRepository _repo;

        public PickupsController(ISwiftPickupRepository repo) 
        {
            _repo = repo;
        }

        public IEnumerable<Pickup> Get(int PickupId)
        {
            IQueryable<Pickup> results;
            //int PickupId = 1;
            if (PickupId > 0)
            {

                results = _repo.GetPickups();
                var pickups = results.Where(t => t.Id == PickupId);
                return pickups;
            }
            else
            {

                results = _repo.GetPickups();

                var pickups = results.OrderByDescending(t => t.Created).Take(25).ToList();
                return pickups;
            }

    }

    public HttpResponseMessage Post([FromBody]Pickup newPickup)
    {
        if (newPickup.Created == default(DateTime))
        {
            newPickup.Created = DateTime.UtcNow;
        }
        if (_repo.AddPickup(newPickup) && _repo.Save())
        { 
            return Request.CreateResponse(HttpStatusCode.Created, newPickup);
        }
        return Request.CreateResponse(HttpStatusCode.BadRequest);
    }

    }
}
