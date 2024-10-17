using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs06_mongo
{
    internal class MongoCRUD
    {
        private IMongoDatabase _db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient("mongodb://student:Educat1on@10.10.10.160:27017/?authSource=playground");
            _db = client.GetDatabase(database);
        }

        public void Create<T>(T entity) where T : class
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            collection.InsertOne(entity);
        }

        public void Create<T>(string collectionName, T entity) where T : class
        {
            var collection = _db.GetCollection<T>(collectionName);
            collection.InsertOne(entity);
        }

        public List<T> List<T>(string collectionName)
        {
            var collection = _db.GetCollection<T>(collectionName);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T Read<T>(string collectionName, string id)
        {
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(id));
            return collection.Find(filter).FirstOrDefault();
        }

        public void Delete<T>(string collectionName, string id)
        {
            var collection = _db.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("Id", new ObjectId(id));
            collection.DeleteOne(filter);
        }
    }
}
