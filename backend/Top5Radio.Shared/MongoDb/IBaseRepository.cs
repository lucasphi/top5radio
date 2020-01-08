using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Top5Radio.Shared.MongoDb
{
    public interface IBaseRepository<TData>
    {
        Task<List<TData>> ListAll();

        Task<List<TData>> Filter(Expression<Func<TData, bool>> expression);

        Task UpsertBatch(IEnumerable<TData> documents);
    }
}
