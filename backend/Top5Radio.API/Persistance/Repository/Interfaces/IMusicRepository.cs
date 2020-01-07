using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Persistance.Data;
using Top5Radio.Shared.MongoDb;

namespace Top5Radio.API.Persistance.Repository.Interfaces
{
    public interface IMusicRepository : IBaseRepository<MusicData>
    {
    }
}
