using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.MongoDb
{
    public abstract class MongoDbBaseContext
    {
        public abstract IMongoCollection<TDocument> ConnectToMongo<TDocument>(in string collection);
    }
}
