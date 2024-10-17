using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs06_mongo.Model
{
    [BsonIgnoreExtraElements]
    internal class Address
    {
        public ObjectId Id { get; set; }
        public required string Street { get; set; }
        public required string Municipality { get; set; }
        public uint StreetNumber { get; set; }
    }
}
