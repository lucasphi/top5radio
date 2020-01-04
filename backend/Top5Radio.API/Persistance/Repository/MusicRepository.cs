using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Top5Radio.API.Persistance.Repository.Interfaces;
using Top5Radio.Persistance.Data;

namespace Top5Radio.Data.Repository
{   
    public class MusicRepository : IMusicRepository
    {
        #region Mocking a Database
        internal static IEnumerable<MusicData> DbMock { get; }
        static MusicRepository()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "spotify-top100-2018.json");

            if (!File.Exists(path))
            {
                throw new Exception("Music json not found");
            }
            
            var json = File.ReadAllText(path);
            DbMock = JsonConvert.DeserializeObject<List<MusicData>>(json);
        }
        #endregion

        public IEnumerable<MusicData> ListAll()
        {
            return DbMock.ToList();
        }
    }
}
