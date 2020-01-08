using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Top5Radio.Admin.Controllers;
using Top5Radio.Admin.Domain;
using Top5Radio.Admin.Domain.Models;
using Top5Radio.Admin.Persistance.Data;
using Top5Radio.Admin.Persistance.Repository.Interfaces;
using Xunit;

namespace Top5Radio.UnitTests.ControllerTests
{
    public class AdminControllerTests
    {
        private readonly Mock<IUserVoteDomainService> _musicDomainServiceMock;
        private readonly Mock<IUserVoteRepository> _userVoteRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly AdminController controller;

        public AdminControllerTests()
        {
            _musicDomainServiceMock = new Mock<IUserVoteDomainService>();
            _userVoteRepositoryMock = new Mock<IUserVoteRepository>();
            _mapperMock = new Mock<IMapper>();

            controller = new AdminController(_musicDomainServiceMock.Object, _userVoteRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task TestTop5Songs()
        {
            _userVoteRepositoryMock.Setup(f => f.Filter(It.IsAny<Expression<Func<UserVoteData, bool>>>()))
                .ReturnsAsync(TestsMockAdmin.MostVotedMusicDataMock);

            var result = await controller.CalculateTopSongs();

            result.Should().BeOfType(typeof(OkObjectResult));
            (result as OkObjectResult).Value.Should().BeEquivalentTo(TestsMockAdmin.MostVotedMusicResultMock);
        }

        [Fact]
        public async Task TestUserConsolidation()
        {
            _userVoteRepositoryMock.Setup(f => f.Filter(It.IsAny<Expression<Func<UserVoteData, bool>>>()))
                .ReturnsAsync(TestsMockAdmin.MostVotedMusicDataMock);

            _mapperMock.Setup(f => f.Map<List<UserVote>>(It.IsAny<object>()))
                .Returns(TestsMockAdmin.MostVotedMusicMock);

            IEnumerable<UserVote> top5music = null;
            _musicDomainServiceMock.Setup(f => f.ConsolidateUserVotes(It.IsAny<IEnumerable<UserVote>>()))
                .Callback<IEnumerable<UserVote>>(obj => top5music = obj);

            var result = await controller.CalculateUserContribution();

            result.Should().BeOfType(typeof(OkObjectResult));
            top5music.Should().BeEquivalentTo(TestsMockAdmin.MostVotedMusicResultMock);
        }
    }
}
