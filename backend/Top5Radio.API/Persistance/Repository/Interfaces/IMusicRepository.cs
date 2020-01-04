using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Persistance.Data;

namespace Top5Radio.API.Persistance.Repository.Interfaces
{
    public interface IMusicRepository
    {
        IEnumerable<MusicData> ListAll();
    }
}
