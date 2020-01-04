using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top5Radio.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusicsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<object> List()
        {
            return new List<object>
            {
                new { Name = "Lucas" }
            };
        }
    }
}
