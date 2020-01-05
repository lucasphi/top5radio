using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top5Radio.Admin.Domain.Models
{
    public class Music
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Voted { get; set; }
    }
}
