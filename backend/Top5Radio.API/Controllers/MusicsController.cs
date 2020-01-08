using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Models;
using Top5Radio.API.Persistance.Data;
using Top5Radio.API.Persistance.Repository.Interfaces;

namespace Top5Radio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicRepository _musicRepository;
        private readonly IUserVoteRepository _voteRepository;

        public MusicsController(IMusicRepository musicRepository,
                                IUserVoteRepository voteRepository)
        {
            _musicRepository = musicRepository;
            _voteRepository = voteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _musicRepository.ListAll());
        }

        [HttpPost("vote")]
        public async Task<IActionResult> ChooseTopFive([FromBody] TopSongs model)
        {            
            var songs = _musicRepository.Filter(f => model.Songs.Contains(f.Id));
            var userSongs = await _voteRepository.Filter(f => model.Songs.Contains(f.Id));

            var updatedSongs = new List<UserVoteData>();
            foreach (var votedSong in model.Songs)
            {
                var song = userSongs.FirstOrDefault(f => f.Id == votedSong);
                if (song == null)
                {
                    var baseSong = (await songs).FirstOrDefault(f => f.Id == votedSong);
                    song = new UserVoteData()
                    {
                        Id = baseSong.Id,
                        Name = baseSong.Name,
                    };
                }
                song.Voted += 1;
                song.Users.Add(model.Username);
                updatedSongs.Add(song);
            }

            await _voteRepository.UpsertBatch(updatedSongs);

            return Ok();
        }
    }
}
