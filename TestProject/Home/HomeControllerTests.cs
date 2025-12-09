using Batch25JenkinsPipeline.Models;
using Batch25JenkinsPipeline.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

[TestFixture]
public class HomeControllerTests
{
    private Mock<ILogger<HomeController>> _loggerMock;

    [SetUp]
    public void SetUp()
    {
        _loggerMock = new Mock<ILogger<HomeController>>();
    }

    [TearDown]
    public void TearDown()
    {
        _loggerMock = null;
    }

    [Test]
    public void Constructor_ShouldInitializeController_WithDependencies()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<HomeController>>();

        // Act
        using var controller = new HomeController(loggerMock.Object);

        // Assert
        Assert.That(controller, Is.Not.Null);
        Assert.That(controller, Is.InstanceOf<HomeController>());
    }

    [Test]
    public void Index_ShouldReturnViewResult()
    {
        // Arrange
        using var controller = new HomeController(_loggerMock.Object);

        // Act
        var result = controller.Index();

        // Assert
        Assert.That(result, Is.InstanceOf<ViewResult>());
    }

    [Test]
    public void Index_ShouldReturnView_WithProductModel()
    {
        // Arrange
        using var controller = new HomeController(_loggerMock.Object);

        // Act
        var result = controller.Index() as ViewResult;

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Model, Is.InstanceOf<List<Product>>());
    }

    [Test]
    public void Index_ShouldReturnCorrectNumberOfProducts()
    {
        // Arrange
        using var controller = new HomeController(_loggerMock.Object);

        // Act
        var result = controller.Index() as ViewResult;
        var model = result.Model as List<Product>;

        // Assert
        Assert.That(model, Is.Not.Null);
        Assert.That(model.Count, Is.EqualTo(11));
    }

    // ... rest of the tests with 'using var controller' in each test method
}