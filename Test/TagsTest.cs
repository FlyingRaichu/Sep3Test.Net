using Application.DaoInterfaces;
using Application.Logic;
using Domain.DTOs.Tag;
using Moq;

namespace Test
{
    [TestFixture]
    public class TagLogicTests
    {
        [Test]
        public async Task CreateTag()
        {
            var mockTagDao = new Mock<ITagDao>();
            var logic = new TagLogic(mockTagDao.Object);
            var dto = new TagCreationDto("test");
            mockTagDao.Setup(dao => dao.CreateAsync(It.IsAny<Tag>()))
                .ReturnsAsync(new Tag { Id = 1, TagName = dto.Name });

            var result = await logic.CreateAsync(dto);

            Assert.IsNotNull(result);
            Assert.That(result.TagName, Is.EqualTo(dto.Name));
            mockTagDao.Verify(dao => dao.CreateAsync(It.IsAny<Tag>()), Times.Once);
        }

        [Test]
        public async Task UpdateTag()
        {
            var mockTagDao = new Mock<ITagDao>();
            var logic = new TagLogic(mockTagDao.Object);
            var dto = new TagUpdateDto(1)
                {Name = "update"};
            var existingTag = new Tag { Id = 1, TagName = "exists" };

            mockTagDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(existingTag);

            mockTagDao.Setup(dao => dao.UpdateAsync(It.IsAny<Tag>()))
                .Returns(Task.CompletedTask);

            await logic.UpdateAsync(dto);

            mockTagDao.Verify(dao => dao.GetByIdAsync(dto.Id), Times.Once);
            mockTagDao.Verify(dao => dao.UpdateAsync(It.IsAny<Tag>()), Times.Once);
        }

        [Test]
        public async Task DeleteTag()
        {
            var mockTagDao = new Mock<ITagDao>();
            var logic = new TagLogic(mockTagDao.Object);
            var tagId = 1;

            mockTagDao.Setup(dao => dao.DeleteAsync(It.IsAny<int>()))
                .Returns(Task.CompletedTask);

            await logic.DeleteAsync(tagId);

            mockTagDao.Verify(dao => dao.DeleteAsync(tagId), Times.Once);
        }

        [Test]
        public async Task GetTag()
        {
            var mockTagDao = new Mock<ITagDao>();
            var logic = new TagLogic(mockTagDao.Object);
            var tagId = 1;
            var expectedTag = new Tag { Id = tagId, TagName = "TestTag" };

            mockTagDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(expectedTag);

            var result = await logic.GetByIdAsync(tagId);

            Assert.IsNotNull(result);
            Assert.That(result, Is.EqualTo(expectedTag));
            mockTagDao.Verify(dao => dao.GetByIdAsync(tagId), Times.Once);
        }
        
        [Test]
        public async Task GetTagsWithId()
        {
            var mockTagDao = new Mock<ITagDao>();
            var logic = new TagLogic(mockTagDao.Object);
            var tagIds = new List<int> { 1, 2, 3 };
            var expectedTags = tagIds.Select(id => new Tag { Id = id, TagName = $"Tag{id}" });

            mockTagDao.Setup(dao => dao.GetAllWithIdAsync(It.IsAny<List<int>>()))
                .ReturnsAsync(expectedTags);

            var result = await logic.GetAllWithIdAsync(tagIds);

            Assert.IsNotNull(result);
            CollectionAssert.AreEquivalent(expectedTags, result);
            mockTagDao.Verify(dao => dao.GetAllWithIdAsync(tagIds), Times.Once);
        }
    }
}
