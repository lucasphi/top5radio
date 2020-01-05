using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Top5Radio.Admin.Domain.Models;
using Top5Radio.Admin.Persistance.Data;

namespace Top5Radio.Admin.Persistance.Repository.Interfaces
{
    public interface IMusicRepository
    {
        IEnumerable<Music> Filter(Expression<Func<MusicData, bool>> expression);

        void BatchUpdate(IEnumerable<Music> musics);
    }
}
