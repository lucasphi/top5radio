using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top5Radio.Admin.Domain.Models
{
    public class User
    {
        public string Username { get; set; }

        public int TotalVotes { get; set; }
    }
}
