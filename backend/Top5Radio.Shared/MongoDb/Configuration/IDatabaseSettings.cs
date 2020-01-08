using System;
using System.Collections.Generic;
using System.Text;

namespace Top5Radio.Shared.MongoDb.Configuration
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
