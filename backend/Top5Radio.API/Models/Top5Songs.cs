using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top5Radio.API.Models
{
    public class Top5Songs
    {
        public string Username { get; set; }

        public List<Song> Songs { get; set; }

        public class Song
        {
            public string Id { get; set; }

            public string Name { get; set; }
        }
    }
}
