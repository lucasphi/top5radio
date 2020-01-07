using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Top5Radio.API.Persistance.Repository.Interfaces;
using Top5Radio.Persistance.Data;
using Top5Radio.Shared.MongoDb;
using Top5Radio.Shared.MongoDb.Configuration;

namespace Top5Radio.Data.Repository
{
    public class MusicRepository : BaseRepository<MusicData>, IMusicRepository
    {
        public MusicRepository(IDatabaseSettings dbSettings)
            : base (dbSettings)
        { }

        public override string CollectionName => "Musics";
    }
}
