﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Top5Radio.Admin.Domain.Models
{
    public class UserVote
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Voted { get; set; }

        public List<string> Users { get; set; }
    }
}
