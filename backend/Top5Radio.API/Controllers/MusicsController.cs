using Microsoft.AspNetCore.Mvc;
using Top5Radio.API.Persistance.Repository.Interfaces;

namespace Top5Radio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicRepository _musicRepository;

        public MusicsController(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_musicRepository.ListAll());
        }
    }
}
