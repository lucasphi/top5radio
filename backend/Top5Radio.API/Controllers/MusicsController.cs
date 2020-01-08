using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Models;
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
            var songs = await _voteRepository.Filter(f => model.Songs.Any(s => s == f.Id));

            foreach (var song in songs)
            {
                song.Voted += 1;
                song.Users.Add(model.Username);
            }

            await _voteRepository.UpsertBatch(songs);

            return Ok();
        }
    }
}
