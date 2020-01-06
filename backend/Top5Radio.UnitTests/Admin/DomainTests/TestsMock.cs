using System;
using System.Collections.Generic;
using System.Text;
using Top5Radio.Admin.Domain.Models;

namespace Top5Radio.UnitTests.Admin.DomainTests
{
    static class TestsMock
    {
        public static IEnumerable<object[]> ConsolidateMocks => new List<object[]>
        {
            new object[]
            {
                null,
                new List<User>()
            },
            new object[]
            {
                new List<Music>()
                {
                    new Music()
                    {
                        Id = "1",
                        Voted = 2,
                        Users = new List<string>() { "Test1", "Test2" }
                    },
                    new Music()
                    {
                        Id = "2",
                        Voted = 1,
                        Users = new List<string>() { "Test2" }
                    },
                    new Music()
                    {
                        Id = "3",
                        Voted = 3,
                        Users = new List<string>() { "Test2", "Test3", "Test4" }
                    },
                    new Music()
                    {
                        Id = "4",
                        Voted = 3,
                        Users = new List<string>() { "Test3", "Test5" }
                    },
                    new Music()
                    {
                        Id = "5",
                        Voted = 3,
                        Users = new List<string>() { "Test1", "Test6", "Test3" }
                    },
                },
                new List<User>()
                {
                    new User()
                    {
                        Username = "Test1",
                        TotalVotes = 2
                    },
                    new User()
                    {
                        Username = "Test2",
                        TotalVotes = 3
                    },
                    new User()
                    {
                        Username = "Test3",
                        TotalVotes = 3
                    },
                    new User()
                    {
                        Username = "Test4",
                        TotalVotes = 1
                    },
                    new User()
                    {
                        Username = "Test5",
                        TotalVotes = 1
                    },
                    new User()
                    {
                        Username = "Test6",
                        TotalVotes = 1
                    }
                }
            },
        };
    }
}
