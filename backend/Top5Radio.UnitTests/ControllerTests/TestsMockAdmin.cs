using System;
using System.Collections.Generic;
using System.Text;
using Top5Radio.Admin.Domain.Models;
using Top5Radio.Admin.Persistance.Data;

namespace Top5Radio.UnitTests.ControllerTests
{
    static class TestsMockAdmin
    {
        public static List<UserVoteData> MostVotedMusicDataMock => new List<UserVoteData>()
        {
            new UserVoteData()
            {
                Id = "1",
                Voted = 0,
            },
            new UserVoteData()
            {
                Id = "2",
                Voted = 3,
            },
            new UserVoteData()
            {
                Id = "3",
                Voted = 0,
            },
            new UserVoteData()
            {
                Id = "4",
                Voted = 10,
            },
            new UserVoteData()
            {
                Id = "5",
                Voted = 0,
            },
            new UserVoteData()
            {
                Id = "6",
                Voted = 2,
            },
            new UserVoteData()
            {
                Id = "7",
                Voted = 1,
            },
            new UserVoteData()
            {
                Id = "8",
                Voted = 4,
            },
            new UserVoteData()
            {
                Id = "9",
                Voted = 0,
            },
            new UserVoteData()
            {
                Id = "10",
                Voted = 5,
            },
        };

        public static List<UserVote> MostVotedMusicMock => new List<UserVote>()
        {
            new UserVote()
            {
                Id = "4",
                Voted = 10,
            },
            new UserVote()
            {
                Id = "10",
                Voted = 5,
            },
            new UserVote()
            {
                Id = "8",
                Voted = 4,
            },
            new UserVote()
            {
                Id = "2",
                Voted = 3,
            },
            new UserVote()
            {
                Id = "6",
                Voted = 2,
            },
        };

        public static List<UserVote> MostVotedMusicResultMock => new List<UserVote>()
        {
            new UserVote()
            {
                Id = "4",
                Voted = 10,
                Users = new List<string>(),
            },
            new UserVote()
            {
                Id = "10",
                Voted = 5,
                Users = new List<string>(),
            },
            new UserVote()
            {
                Id = "8",
                Voted = 4,
                Users = new List<string>(),
            },
            new UserVote()
            {
                Id = "2",
                Voted = 3,
                Users = new List<string>(),
            },
            new UserVote()
            {
                Id = "6",
                Voted = 2,
                Users = new List<string>(),
            },
        };
    }
}
