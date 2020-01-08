using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Shared.MongoDb;

namespace Top5Radio.API.Persistance.Data
{
    public class UserVoteData : IDocument
    {
        [BsonId]
        public string Id { get; set; }

        public string Name { get; set; }

        public int Voted { get; set; }

        public List<string> Users { get; set; } = new List<string>();
    }
}
