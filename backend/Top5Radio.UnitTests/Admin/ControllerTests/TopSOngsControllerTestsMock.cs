using System;
using System.Collections.Generic;
using System.Text;
using Top5Radio.Admin.Domain.Models;

namespace Top5Radio.UnitTests.Admin.ControllerTests
{
    static class TopSOngsControllerTestsMock
    {
        public static List<Music> MusicsMock => new List<Music>()
                {
                    new Music()
                    {
                        Id = "1",
                        Voted = 0
                    },
                    new Music()
                    {
                        Id = "2",
                        Voted = 3
                    }
                };

        public static List<Music> MusicsUpdatedMock => new List<Music>()
                {
                    new Music()
                    {
                        Id = "1",
                        Voted = 1
                    },
                    new Music()
                    {
                        Id = "2",
                        Voted = 4
                    }
                };
    }
}
