using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Linq;
using System.Web;

namespace SwiftPickup.Data
{
    public class SwiftPickupRepository : ISwiftPickupRepository
    {

        private SwiftPickupContext _ctx;

        public SwiftPickupRepository(SwiftPickupContext ctx)
        {
            _ctx = ctx;   
        }

        public IQueryable<Topic> GetTopics()
        {
            return _ctx.Topics;
        }

        public IQueryable<Pickup> GetPickups()
        {
            return _ctx.Pickups;
        }

        public IQueryable<Driver> GetDrivers()
        {
            return _ctx.Drivers;
        }

        public IQueryable<UserLocation> GetUserLocations()
        {
            return _ctx.UserLocations;
        }

        public IQueryable<Reply> GetRepliesByTopic(int topicId)
        {
            return _ctx.Replies.Where(r => r.TopicId == topicId);
        }

        public IQueryable<Pickup> GetPickupsById(int pickupId)
        {
            return _ctx.Pickups.Where(r => r.Id == pickupId);
        }

        public bool Save()
        {
            try
            {
                return _ctx.SaveChanges() > 0;
            }
            catch (Exception ex) 
            {
                //TODO log this error
                return false;
            }
        }

        public bool AddUserLocation(UserLocation newUserLocation)
        {
            try
            { 
                _ctx.UserLocations.Add(newUserLocation);
                return true;
            }
            catch (Exception ex)
            {
            return false;
            }
        }
       
        public bool AddPickup(Pickup newPickup)
        {
            try
            {
                _ctx.Pickups.Add(newPickup);
                return true;
            }
            catch (Exception ex)
            { 
                //TODO log the error
                return false;
            }
        }
        
        public bool AddTopic(Topic NewTopic)
        {
            try
            {
                _ctx.Topics.Add(NewTopic);
                return true;
            }
            catch (Exception ex)
            { 
            //TODO Log this error
                return false;
            }
        }

        public bool AddDriver(Driver newDriver)
        {
            try
            {
                _ctx.Drivers.Add(newDriver);
                return true;
            }
            catch (Exception ex)
            { 
                //TODO log this error
                return false;
            }
        }

        public IQueryable<Topic> GetTopicsIncludingReplies()
        {
            return _ctx.Topics.Include("Replies");
        }

        public bool AddReply(Reply newReply)
        {
              try
            {
                _ctx.Replies.Add(newReply);
                return true;
            }
            catch (Exception ex)
            { 
            //TODO Log this error
                return false;
            }
        }

    }
    }
