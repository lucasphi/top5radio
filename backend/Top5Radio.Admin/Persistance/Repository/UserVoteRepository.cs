using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Persistance.Data;
using Top5Radio.Admin.Persistance.Repository.Interfaces;
using Top5Radio.Shared;
using Top5Radio.Shared.MongoDb;
using Top5Radio.Shared.MongoDb.Configuration;

namespace Top5Radio.Admin.Persistance.Repository
{
    public class UserVoteRepository : BaseRepository<UserVoteData>, IUserVoteRepository
    {
        public UserVoteRepository(IDatabaseSettings dbSettings)
            : base(dbSettings)
        { }

        public override string CollectionName => Constants.Database.VOTES_COLLECTION;
    }
}
