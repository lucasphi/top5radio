using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Top5Radio.Shared.MongoDb.Configuration
{
    static class Setup
    {
        public static void PopulateDatabase(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            var collection
        }

        private static void CreateData<TData>()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "spotify-top100-2018.json");

            if (!File.Exists(path))
            {
                throw new Exception("Music json not found");
            }

            var json = File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<List<TData>>(json);
        }
    }
}
