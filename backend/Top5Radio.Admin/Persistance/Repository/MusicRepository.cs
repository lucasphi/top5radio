using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Top5Radio.Admin.Domain.Models;
using Top5Radio.Admin.Persistance.Data;
using Top5Radio.Admin.Persistance.Repository.Interfaces;

namespace Top5Radio.Admin.Persistance.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly IMapper _mapper;

        public MusicRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Mocking the db that would be populated by the event grid
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

        public IEnumerable<Music> Filter(Expression<Func<MusicData, bool>> expression)
        {
            IEnumerable<MusicData> result = DbMock.Where(expression.Compile());
            return _mapper.Map<List<Music>>(result);
        }

        public void BatchUpdate(IEnumerable<Music> musics)
        {
            // Fakely save the data
            foreach (var music in musics)
            {
                DbMock.First(f => f.Id == music.Id).Voted = music.Voted;
            }
        }
    }
}
