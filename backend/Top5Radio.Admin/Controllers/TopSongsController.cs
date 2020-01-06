using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Models;
using Top5Radio.Admin.Persistance.Repository.Interfaces;

namespace Top5Radio.Admin.Controllers
{
    // Esse controller deveria estar no outro microserviço. Devido ao fato de não estar utilizando um DB real, coloquei neste MS. 
    // Considere um debito técnico a ser ajustado.

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
            var songs = _musicRepository.Filter(f => model.Songs.Any(s => s == f.Id));

            foreach (var song in songs)
            {
                song.Voted += 1;
                song.Users.Add(model.Username);
            }

            _musicRepository.BatchUpdate(songs);

            return Ok();
        }
    }
}
