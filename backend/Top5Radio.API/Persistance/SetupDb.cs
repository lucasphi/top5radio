using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Top5Radio.API.Persistance.Data;
using Top5Radio.Shared;
using Top5Radio.Shared.MongoDb.Configuration;

namespace Top5Radio.API.Persistance.Configuration
{
    static class SetupDb
    {
        public static void PopulateDatabase(IConfiguration configuration)
        {
            var dbSettings = new DatabaseSettings();
            configuration.GetSection("DatabaseSettings").Bind(dbSettings);

            var client = new MongoClient(dbSettings.ConnectionString);
            var database = client.GetDatabase(dbSettings.DatabaseName);

            if (!database.ListCollectionNames().Any())
            {                
                database.CreateCollection(Constants.Database.MUSIC_COLLECTION);
                database.CreateCollection(Constants.Database.VOTES_COLLECTION);

                var data = CreateData<MusicData>();

                var collection = database.GetCollection<MusicData>(Constants.Database.MUSIC_COLLECTION);
                collection.InsertMany(data);
            }
        }

        private static List<TData> CreateData<TData>()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "spotify-top100-2018.json");

            if (!File.Exists(path))
            {
                throw new Exception("Music json not found");
            }

            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<TData>>(json);
        }
    }
}
