﻿using System;
using System.Collections.Generic;
using System.Text;
using Top5Radio.Admin.Domain.Models;

namespace Top5Radio.UnitTests.Admin.ControllerTests
{
    static class TestsMock
    {
        public static List<Music> MusicsMock => new List<Music>()
        {
            new Music()
            {
                Id = "1",
                Voted = 0,
                Users = new List<string>()
            },
            new Music()
            {
                Id = "2",
                Voted = 3,
                Users = new List<string>()
                {
                    "A", "B", "C"
                }
            }
        };

        public static List<Music> MusicsUpdatedMock => new List<Music>()
        {
            new Music()
            {
                Id = "1",
                Voted = 1,
                Users = new List<string>() { "Test" }
            },
            new Music()
            {
                Id = "2",
                Voted = 4,
                Users = new List<string>()
                {
                    "A", "B", "C", "Test"
                }
            }
        };


        public static List<Music> MostVotedMusicMock => new List<Music>()
        {
            new Music()
            {
                Id = "1",
                Voted = 0,
            },
            new Music()
            {
                Id = "2",
                Voted = 3,
            },
            new Music()
            {
                Id = "3",
                Voted = 0,
            },
            new Music()
            {
                Id = "4",
                Voted = 10,
            },
            new Music()
            {
                Id = "5",
                Voted = 0,
            },
            new Music()
            {
                Id = "6",
                Voted = 2,
            },
            new Music()
            {
                Id = "7",
                Voted = 1,
            },
            new Music()
            {
                Id = "8",
                Voted = 4,
            },
            new Music()
            {
                Id = "9",
                Voted = 0,
            },
            new Music()
            {
                Id = "10",
                Voted = 5,
            },
        };

        public static List<Music> MostVotedMusicResultMock => new List<Music>()
        {
            new Music()
            {
                Id = "4",
                Voted = 10,
            },
            new Music()
            {
                Id = "10",
                Voted = 5,
            },
            new Music()
            {
                Id = "8",
                Voted = 4,
            },
            new Music()
            {
                Id = "2",
                Voted = 3,
            },
            new Music()
            {
                Id = "6",
                Voted = 2,
            },
        };
    }
}
