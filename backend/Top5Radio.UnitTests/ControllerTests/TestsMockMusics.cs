using System;
using System.Collections.Generic;
using System.Text;
using Top5Radio.Admin.Domain.Models;
using Top5Radio.API.Persistance.Data;

namespace Top5Radio.UnitTests.ControllerTests
{
    static class TestsMockMusics
    {
        public static List<MusicData> MusicsMock => new List<MusicData>()
        {
            new MusicData()
            {
                Id = "1",
                Name = "Test 1"  
            },
            new MusicData()
            {
                Id = "2",
                Name = "Test 2"
            },
            new MusicData()
            {
                Id = "3",
                Name = "Test 3"
            },
        };

        public static List<UserVoteData> UserVotesMock => new List<UserVoteData>()
        {
            new UserVoteData()
            {
                Id = "1",
                Voted = 0,
                Users = new List<string>()
            },
            new UserVoteData()
            {
                Id = "2",
                Voted = 3,
                Users = new List<string>()
                {
                    "A", "B", "C"
                }
            }
        };

        public static List<UserVoteData> MusicsUpdatedMock => new List<UserVoteData>()
        {
            new UserVoteData()
            {
                Id = "1",
                Voted = 1,
                Users = new List<string>() { "Test" }
            },
            new UserVoteData()
            {
                Id = "2",
                Voted = 4,
                Users = new List<string>()
                {
                    "A", "B", "C", "Test"
                }
            },
            new UserVoteData()
            {
                Id = "3",
                Name = "Test 3",
                Voted = 1,
                Users = new List<string>() { "Test" }
            },
        };    
    }
}
