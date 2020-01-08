using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Top5Radio.Admin.Domain;
using Top5Radio.Admin.Domain.Models;
using Xunit;

namespace Top5Radio.UnitTests.Admin.DomainTests
{
    public class MusicDomainServiceTests
    {
        [Theory]
        [MemberData(nameof(TestsMock.ConsolidateMocks), MemberType = typeof(TestsMock))]
        public void TestConsolidateUsers(IEnumerable<UserVote> musics, IEnumerable<User> usersResult)
        {
            var domainService = new UserVoteDomainService();

            var users = domainService.ConsolidateUserVotes(musics);

            users.Should().BeEquivalentTo(usersResult);
        }
    }
}
