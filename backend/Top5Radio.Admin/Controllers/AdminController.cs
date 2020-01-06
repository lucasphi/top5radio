using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Domain;
using Top5Radio.Admin.Domain.Models;
using Top5Radio.Admin.Persistance.Repository.Interfaces;

namespace Top5Radio.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMusicDomainService _musicDomainService;
        private readonly IMusicRepository _musicRepository;

        public AdminController(IMusicDomainService musicDomainService,
                               IMusicRepository musicRepository)
        {
            _musicDomainService = musicDomainService;
            _musicRepository = musicRepository;
        }

        [HttpGet("topsongs")]
        public IActionResult CalculateTopSongs()
        {
            IEnumerable<Music> top5 = _musicRepository.Filter(f => f.Voted > 0).OrderByDescending(f => f.Voted).Take(5);
            return Ok(top5);
        }

        [HttpGet("usercontribution")]
        public IActionResult CalculateUserContribution()
        {            
            return Ok();
        }
    }
}
