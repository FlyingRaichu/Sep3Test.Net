using Application.DaoInterfaces;
using Application.Logic;
using Domain.DTOs;
using Domain.DTOs.Review;
using Moq;

namespace Test;

[TestFixture]
public class ReviewLogicTests
{
    private Mock<IReviewDao> mockReviewDao;
    private Mock<IItemDao> mockItemDao;
    private ReviewLogic reviewLogic;

    [SetUp]
    public void SetUp()
    {
        mockReviewDao = new Mock<IReviewDao>();
        mockItemDao = new Mock<IItemDao>();
        reviewLogic = new ReviewLogic(mockReviewDao.Object, mockItemDao.Object);
    }

    [Test]
    public async Task CreateAsync_ValidReview_ReturnsCreatedReview()
    {
        var reviewCreationDto = new ReviewCreationDto("Great Product", 5, "JohnDoe", 1);

        var item = new Item
        {
            Id = 1,
            Title = "Blue yarn",
            Description = "This be blue yarn",
            Price = 12.5,
            Manufacturer = "m inc.",
            Stock = 10,
            Tags = { 1, 2, 3 },
            DiscountPercentage = 10
        };
        mockItemDao.Setup(dao => dao.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(item);
        mockReviewDao.Setup(dao => dao.CreateAsync(It.IsAny<Review>())).ReturnsAsync(new Review());

        var createdReview = await reviewLogic.CreateAsync(reviewCreationDto);

        // Assert
        Assert.NotNull(createdReview);
        // Add more assertions as needed
    }

    [Test]
    public async Task CreateAsync_InvalidReview_ThrowsException()
    {
        var reviewCreationDto = new ReviewCreationDto("Great Product", 6, "JohnDoe", -1);


        // Act & Assert
        Assert.ThrowsAsync<Exception>(async () => await reviewLogic.CreateAsync(reviewCreationDto));
    }

    // Add more tests for other methods in the ReviewLogic class

    [Test]
    public async Task GetByIdAsync_ExistingReview_ReturnsReview()
    {
        // Arrange
        var existingReviewId = 1;
        mockReviewDao.Setup(dao => dao.GetByIdAsync(existingReviewId)).ReturnsAsync(new Review());

        // Act
        var review = await reviewLogic.GetByIdAsync(existingReviewId);

        // Assert
        Assert.NotNull(review);
        // Add more assertions as needed
    }

    [Test]
    public async Task GetByIdAsync_NonExistingReview_ThrowsException()
    {
        // Arrange
        var nonExistingReviewId = 999;
        mockReviewDao.Setup(dao => dao.GetByIdAsync(nonExistingReviewId)).ReturnsAsync((Review)null);

        // Act & Assert
        Assert.ThrowsAsync<Exception>(async () => await reviewLogic.GetByIdAsync(nonExistingReviewId));
    }

    // Add more tests for other methods in the ReviewLogic class
}