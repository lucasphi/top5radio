using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Top5Radio.Admin.Controllers;
using Top5Radio.Admin.Domain.Models;
using Top5Radio.Admin.Persistance.Data;
using Top5Radio.Admin.Persistance.Repository.Interfaces;
using Xunit;

namespace Top5Radio.UnitTests.Admin.ControllerTests
{
    public class TopSongsControllerTests
    {
        private readonly Mock<IMusicRepository> _musicRepositoryMock;

        private readonly TopSongsController controller;

        public TopSongsControllerTests()
        {
            _musicRepositoryMock = new Mock<IMusicRepository>();

            controller = new TopSongsController(_musicRepositoryMock.Object);
        }

        [Fact]
        public void TestSongChoosingApi()
        {
            _musicRepositoryMock.Setup(f => f.Filter(It.IsAny<Expression<Func<MusicData, bool>>>()))
                .Returns(TopSOngsControllerTestsMock.MusicsMock);

            IEnumerable<Music> updatedMusic = null;
            _musicRepositoryMock.Setup(f => f.BatchUpdate(It.IsAny<IEnumerable<Music>>()))
                .Callback<IEnumerable<Music>>(obj => updatedMusic = obj);

            controller.ChooseTopFive(new Top5Radio.Admin.Models.Top5Songs());

            updatedMusic.Should().BeEquivalentTo(TopSOngsControllerTestsMock.MusicsUpdatedMock);
        }
    }
}
