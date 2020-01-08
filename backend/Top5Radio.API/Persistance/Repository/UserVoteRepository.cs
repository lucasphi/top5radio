using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.API.Persistance.Data;
using Top5Radio.API.Persistance.Repository.Interfaces;
using Top5Radio.Shared;
using Top5Radio.Shared.MongoDb;
using Top5Radio.Shared.MongoDb.Configuration;

namespace Top5Radio.API.Persistance.Repository
{
    public class UserVoteRepository : BaseRepository<UserVoteData>, IUserVoteRepository
    {
        public UserVoteRepository(IDatabaseSettings dbSettings)
            : base(dbSettings)
        { }

        public override string CollectionName => Constants.Database.VOTES_COLLECTION;
    }
}
