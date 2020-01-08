using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Persistance.Data;
using Top5Radio.Shared.MongoDb;

namespace Top5Radio.Admin.Persistance.Repository.Interfaces
{
    public interface IUserVoteRepository : IBaseRepository<UserVoteData>
    {
    }
}
