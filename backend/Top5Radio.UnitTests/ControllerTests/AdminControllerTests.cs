using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
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
        private readonly Mock<IMusicDomainService> _musicDomainServiceMock;
        private readonly Mock<IMusicRepository> _musicRepositoryMock;

        private readonly AdminController controller;

        public AdminControllerTests()
        {
            _musicDomainServiceMock = new Mock<IMusicDomainService>();
            _musicRepositoryMock = new Mock<IMusicRepository>();

            controller = new AdminController(_musicDomainServiceMock.Object, _musicRepositoryMock.Object);
        }

        [Fact]
        public void TestTop5Songs()
        {
            _musicRepositoryMock.Setup(f => f.Filter(It.IsAny<Expression<Func<MusicData, bool>>>()))
                .Returns(TestsMock.MostVotedMusicMock);

            var result = controller.CalculateTopSongs();

            result.Should().BeOfType(typeof(OkObjectResult));
            (result as OkObjectResult).Value.Should().BeEquivalentTo(TestsMock.MostVotedMusicResultMock);
        }

        [Fact]
        public void TestUserConsolidation()
        {
            _musicRepositoryMock.Setup(f => f.Filter(It.IsAny<Expression<Func<MusicData, bool>>>()))
                .Returns(TestsMock.MostVotedMusicMock);

            IEnumerable<Music> top5music = null;
            _musicDomainServiceMock.Setup(f => f.ConsolidateUserVotes(It.IsAny<IEnumerable<Music>>()))
                .Callback<IEnumerable<Music>>(obj => top5music = obj);

            var result = controller.CalculateUserContribution();

            result.Should().BeOfType(typeof(OkObjectResult));
            top5music.Should().BeEquivalentTo(TestsMock.MostVotedMusicResultMock);
        }
    }
}
