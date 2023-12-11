using Application.DaoInterfaces;
using Application.Logic;
using Domain.DTOs.User;
using Moq;

namespace Test
{
    [TestFixture]
    public class UserLogicTests
    {
        [Test]
        public async Task CreateUser()
        {
            var mockUserDao = new Mock<IUserDao>();
            var logic = new UserLogic(mockUserDao.Object);
            var dto = new UserCreationDto("test", "pass", "test@example.com", "user");
            
            mockUserDao.Setup(dao => dao.GetByUsernameAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);
            mockUserDao.Setup(dao => dao.GetByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((User)null);
            mockUserDao.Setup(dao => dao.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(new User { Id = 1, Username = dto.Username, Email = dto.Email, Role = dto.Role });

            var result = await logic.CreateAsync(dto);

            Assert.IsNotNull(result);
            Assert.That(result.Username, Is.EqualTo(dto.Username));
            Assert.That(result.Email, Is.EqualTo(dto.Email));
            Assert.That(result.Role, Is.EqualTo(dto.Role));

            mockUserDao.Verify(dao => dao.GetByUsernameAsync(It.IsAny<string>()), Times.Once);
            mockUserDao.Verify(dao => dao.GetByEmailAsync(It.IsAny<string>()), Times.Once);
            mockUserDao.Verify(dao => dao.CreateAsync(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public async Task ValidateUser()
        {
            var mockUserDao = new Mock<IUserDao>();
            var logic = new UserLogic(mockUserDao.Object);
            var dto = new UserValidationDto("test", "pass");
            var expectedUser = new User { Id = 1, Username = "test", Role = "user" };

            mockUserDao.Setup(dao => dao.ValidateUser(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(expectedUser);

            var result = await logic.ValidateUser(dto.Username, dto.Password);

            Assert.IsNotNull(result);
            Assert.AreEqual(expectedUser.Id, result.Id);
            Assert.AreEqual(expectedUser.Username, result.Username);
            Assert.AreEqual(expectedUser.Role, result.Role);
            mockUserDao.Verify(dao => dao.ValidateUser(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task GetUserById()
        {
            var mockUserDao = new Mock<IUserDao>();
            var logic = new UserLogic(mockUserDao.Object);
            var userId = 1;
            var expectedUser = new User { Id = userId, Username = "test", Role = "user" };

            mockUserDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedUser);

            var result = await logic.GetByIdAsync(userId);

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expectedUser));
            mockUserDao.Verify(dao => dao.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
