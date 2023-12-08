using Application.DaoInterfaces;
using Application.Logic;
using Domain.DTOs;
using Moq;

namespace Test
{
    [TestFixture]
    public class FavoriteLogicTests
    {
        [Test]
        public async Task CreateFavorite()
        {
            var mockDao = new Mock<IFavoriteDao>();
            var logic = new FavoriteLogic(mockDao.Object);
            var dto = new FavoriteDto(1, 1);

            mockDao.Setup(dao => dao.CreateAsync(It.IsAny<Favorite>()))
                .ReturnsAsync(new Favorite { UserId = dto.UserId, ItemId = dto.ItemId });

            var result = await logic.CreateAsync(dto);

            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(dto.UserId));
            Assert.That(result.ItemId, Is.EqualTo(dto.ItemId));

            mockDao.Verify(dao => dao.CreateAsync(It.IsAny<Favorite>()), Times.Once);
        }

        [Test]
        public async Task GetFavorite()
        {
            var mockDao = new Mock<IFavoriteDao>();
            var logic = new FavoriteLogic(mockDao.Object);
            var dto = new FavoriteDto(1, 1);

            mockDao.Setup(dao => dao.GetAsync(It.IsAny<Favorite>()))
                .ReturnsAsync(new Favorite { UserId = dto.UserId, ItemId = dto.ItemId });
            var result = await logic.GetAsync(dto);

            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(dto.UserId));
            Assert.That(result.ItemId, Is.EqualTo(dto.ItemId));
            mockDao.Verify(dao => dao.GetAsync(It.IsAny<Favorite>()), Times.Once);
        }

        [Test]
        public async Task DeleteFavorite()
        {
            var mockDao = new Mock<IFavoriteDao>();
            var logic = new FavoriteLogic(mockDao.Object);
            var dto = new FavoriteDto(1, 1);

            mockDao.Setup(dao => dao.DeleteAsync(It.IsAny<Favorite>()))
                .ReturnsAsync(new Favorite { UserId = dto.UserId, ItemId = dto.ItemId });

            var result = await logic.DeleteAsync(dto);

            Assert.IsNotNull(result);
            Assert.That(result.UserId, Is.EqualTo(dto.UserId));
            Assert.That(result.ItemId, Is.EqualTo(dto.ItemId));

            mockDao.Verify(dao => dao.DeleteAsync(It.IsAny<Favorite>()), Times.Once);
        }
        
        [Test]
        public async Task CreateInvalid()
        {
            var mockDao = new Mock<IFavoriteDao>();
            var logic = new FavoriteLogic(mockDao.Object);
            var invalidDto = new FavoriteDto(0, 0);

            mockDao.Setup(dao => dao.CreateAsync(It.IsAny<Favorite>())).Verifiable();

            var result = await logic.CreateAsync(invalidDto);

            Assert.IsNull(result);
        }

        [Test]
        public async Task GetInvalid()
        {
            var mockDao = new Mock<IFavoriteDao>();
            var logic = new FavoriteLogic(mockDao.Object);
            var invalidDto = new FavoriteDto(0, 0);

            mockDao.Setup(dao => dao.GetAsync(It.IsAny<Favorite>())).Verifiable();

            var result = await logic.GetAsync(invalidDto);

            Assert.IsNull(result);
        }

        [Test]
        public async Task DeleteInvalid()
        {
            var mockDao = new Mock<IFavoriteDao>();
            var logic = new FavoriteLogic(mockDao.Object);
            var invalidDto = new FavoriteDto(0, 0);

            mockDao.Setup(dao => dao.DeleteAsync(It.IsAny<Favorite>())).Verifiable();

            var result = await logic.DeleteAsync(invalidDto);

            Assert.IsNull(result);
        }

    }
    
}
