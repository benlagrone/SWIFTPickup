using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftPickup.Data
{
    public interface ISwiftPickupRepository
    {
        IQueryable<Topic> GetTopics();
        IQueryable<Topic> GetTopicsIncludingReplies();
        IQueryable<Reply> GetRepliesByTopic(int topicId);
        IQueryable<UserLocation> GetUserLocations();
        IQueryable<Pickup> GetPickups();
        IQueryable<Driver> GetDrivers();
        IQueryable<Pickup> GetPickupsById(int pickupId);

        bool Save();

        bool AddTopic(Topic NewTopic);
        bool AddReply(Reply newReply);
        bool AddUserLocation(UserLocation newUserLocation);
        bool AddPickup(Pickup newPickup);
        bool AddDriver(Driver newDriver);
    }
}
