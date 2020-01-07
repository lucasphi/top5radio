using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Top5Radio.Shared.MongoDb.Configuration;

namespace Top5Radio.Shared.MongoDb
{
    public abstract class BaseRepository<TData>
    {
        protected readonly IMongoCollection<TData> _collection;

        public abstract string CollectionName { get; }

        public BaseRepository(IDatabaseSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _collection = database.GetCollection<TData>(CollectionName);
        }

        public IEnumerable<TData> ListAll()
        {
            return _collection.AsQueryable().ToList();
        }
    }
}
