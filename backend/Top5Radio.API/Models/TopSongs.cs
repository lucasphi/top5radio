using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top5Radio.Admin.Models
{
    public class TopSongs
    {
        public string Username { get; set; }

        public List<string> Songs { get; set; }
    }
}
