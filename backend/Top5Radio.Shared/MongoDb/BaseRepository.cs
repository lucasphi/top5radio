using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Top5Radio.Shared.MongoDb.Configuration;

namespace Top5Radio.Shared.MongoDb
{
    public abstract class BaseRepository<TData> : IBaseRepository<TData>
        where TData: class, IDocument
    {
        protected readonly IMongoCollection<TData> _collection;

        public abstract string CollectionName { get; }

        public BaseRepository(IDatabaseSettings dbSettings)
        {
            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            _collection = database.GetCollection<TData>(CollectionName);
        }

        public Task<List<TData>> ListAll()
        {
            return _collection.AsQueryable().ToListAsync();
        }

        public Task<List<TData>> Filter(Expression<Func<TData, bool>> expression)
        {
            return _collection.Find(expression).ToListAsync();
        }

        public Task UpsertBatch(IEnumerable<TData> documents)
        {
            var bulkOps = new List<WriteModel<TData>>();
            foreach (var record in documents)
            {
                var upsertOne = new ReplaceOneModel<TData>(
                    Builders<TData>.Filter.Where(x => x.Id == record.Id),
                    record)
                { IsUpsert = true };
                bulkOps.Add(upsertOne);
            }
            return _collection.BulkWriteAsync(bulkOps);
        }
    }
}
