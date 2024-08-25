using Application.Interfaces;
using Domain.Visitors;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application._services
{
    public class VisitorOnlineService : IVisitorOnlineService
    {
        private readonly IMongoDbContext<OnlineVisitors> MongoDbContext;
        private readonly IMongoCollection<OnlineVisitors> mongoCollection;
        public VisitorOnlineService(IMongoDbContext<OnlineVisitors> MongoDbContext)
        {
            this.MongoDbContext= MongoDbContext;
            mongoCollection = MongoDbContext.GetCollection();


        }
        public void ConnectUser(string ClientId)
        {
            var exist=mongoCollection.AsQueryable().FirstOrDefault(p=>p.ClientId == ClientId);
            if (exist == null)
            {

                mongoCollection.InsertOne(new OnlineVisitors { ClientId = ClientId, Time = DateTime.Now });
            }
        }

        public void DisconnectUser(string ClientId)
        {
            mongoCollection.FindOneAndDelete(p=>p.ClientId == ClientId);
        }

        public int GetCount()
        {
            return mongoCollection.AsQueryable().Count();
        }
    }
}
