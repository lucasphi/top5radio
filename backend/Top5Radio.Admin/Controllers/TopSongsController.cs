using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Models;
using Top5Radio.Admin.Persistance.Repository.Interfaces;

namespace Top5Radio.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopSongsController : ControllerBase
    {
        private readonly IMusicRepository _musicRepository;

        public TopSongsController(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        [HttpPost]
        public IActionResult ChooseTopFive([FromBody] Top5Songs model)
        {
            var songs = _musicRepository.Filter(f => model.Songs.Any(s => s.Id == f.Id));

            foreach (var song in songs)
            {
                song.Voted += 1;
            }

            _musicRepository.BatchUpdate(songs);

            return Ok();
        }
    }
}
