using Application.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts.Mongo
{
    public class MongoDbContext<T> : IMongoDbContext<T>
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<T> mongoCollection;
        public MongoDbContext() {
            var client= new MongoClient();
            db = client.GetDatabase("VisitorDb");
            mongoCollection=db.GetCollection<T>(typeof(T).Name);//بدست آوردن نام انتیتی
        }
        public IMongoCollection<T> GetCollection()
        {
            return mongoCollection;
        }
    }
}
