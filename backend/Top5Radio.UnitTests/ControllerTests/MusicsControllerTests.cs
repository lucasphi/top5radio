using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Top5Radio.Admin.Models;
using Top5Radio.API.Controllers;
using Top5Radio.API.Persistance.Data;
using Top5Radio.API.Persistance.Repository.Interfaces;
using Xunit;

namespace Top5Radio.UnitTests.ControllerTests
{
    public class MusicsControllerTests
    {
        private readonly Mock<IMusicRepository> _musicRepositoryMock;
        private readonly Mock<IUserVoteRepository> _userVoteRepositoryMock;

        private readonly MusicsController controller;

        public MusicsControllerTests()
        {
            _musicRepositoryMock = new Mock<IMusicRepository>();
            _userVoteRepositoryMock = new Mock<IUserVoteRepository>();

            controller = new MusicsController(_musicRepositoryMock.Object, _userVoteRepositoryMock.Object);
        }

        [Fact]
        public async Task TestSongChoosingApi()
        {
            _userVoteRepositoryMock.Setup(f => f.Filter(It.IsAny<Expression<Func<UserVoteData, bool>>>()))
                .ReturnsAsync(TestsMock.UserVotesMock);

            IEnumerable<UserVoteData> votes = null;
            _userVoteRepositoryMock.Setup(f => f.UpsertBatch(It.IsAny<IEnumerable<UserVoteData>>()))
                .Callback<IEnumerable<UserVoteData>>(obj => votes = obj);

            var result = await controller.ChooseTopFive(new TopSongs() { Username = "Test" });

            votes.Should().BeEquivalentTo(TestsMock.MusicsUpdatedMock);
            result.Should().BeOfType(typeof(OkResult));
        }
    }
}
