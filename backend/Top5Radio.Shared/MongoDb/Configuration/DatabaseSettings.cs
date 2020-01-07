using System;

namespace Top5Radio.Shared.MongoDb.Configuration
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
