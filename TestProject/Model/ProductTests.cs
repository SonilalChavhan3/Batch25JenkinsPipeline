
namespace TestProject.Model
{
    using Batch25JenkinsPipeline.Models;
    using NUnit.Framework;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Constructor_ShouldInitializeAllProperties_WhenAllParametersProvided()
        {
            // Arrange
            int id = 1;
            string name = "Test Product";
            decimal price = 99.99m;
            string category = "Electronics";
            bool isInStock = true;

            // Act
            var product = new Product(id, name, price, category, isInStock);

            // Assert
            Assert.That(product.Id, Is.EqualTo(id));
            Assert.That(product.Name, Is.EqualTo(name));
            Assert.That(product.Price, Is.EqualTo(price));
            Assert.That(product.Category, Is.EqualTo(category));
            Assert.That(product.IsInStock, Is.EqualTo(isInStock));
        }

        [Test]
        public void Constructor_ShouldSetIsInStockToTrue_WhenIsInStockParameterNotProvided()
        {
            // Arrange
            int id = 1;
            string name = "Test Product";
            decimal price = 99.99m;
            string category = "Electronics";

            // Act
            var product = new Product(id, name, price, category);

            // Assert
            Assert.That(product.IsInStock, Is.True);
        }

        [Test]
        public void Constructor_ShouldSetIsInStockToFalse_WhenExplicitlySetToFalse()
        {
            // Arrange
            int id = 1;
            string name = "Test Product";
            decimal price = 99.99m;
            string category = "Electronics";
            bool isInStock = false;

            // Act
            var product = new Product(id, name, price, category, isInStock);

            // Assert
            Assert.That(product.IsInStock, Is.False);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(100)]
        public void Constructor_ShouldAcceptValidIdValues(int id)
        {
            // Arrange
            string name = "Test Product";
            decimal price = 99.99m;
            string category = "Electronics";

            // Act
            var product = new Product(id, name, price, category);

            // Assert
            Assert.That(product.Id, Is.EqualTo(id));
        }


        [TestCase("")]
        [TestCase("  ")]
        public void Constructor_ShouldAcceptNameValues(string name)
        {
            // Arrange
            int id = 1;
            decimal price = 99.99m;
            string category = "Electronics";

            // Act
            var product = new Product(id, name, price, category);

            // Assert
            Assert.That(product.Name, Is.EqualTo(name));
        }

        [TestCase(0)]
        [TestCase(0.01)]
        [TestCase(999999.99)]
        [TestCase(-100)] // Depending on business rules, you might want to restrict negative prices
        public void Constructor_ShouldAcceptPriceValues(decimal price)
        {
            // Arrange
            int id = 1;
            string name = "Test Product";
            string category = "Electronics";

            // Act
            var product = new Product(id, name, price, category);

            // Assert
            Assert.That(product.Price, Is.EqualTo(price));
        }

        [Test]
        public void Properties_ShouldBeSettable_AfterConstruction()
        {
            // Arrange
            var product = new Product(1, "Initial", 10.00m, "InitialCategory", true);

            // Act
            product.Name = "Updated Name";
            product.Price = 20.00m;
            product.Category = "Updated Category";
            product.IsInStock = false;

            // Assert
            Assert.That(product.Name, Is.EqualTo("Updated Name"));
            Assert.That(product.Price, Is.EqualTo(20.00m));
            Assert.That(product.Category, Is.EqualTo("Updated Category"));
            Assert.That(product.IsInStock, Is.False);
        }

        [Test]
        public void Id_ShouldNotChange_AfterConstruction()
        {
            // This test assumes Id should be immutable (common pattern)
            // If your design allows changing Id, remove this test

            // Arrange
            var product = new Product(1, "Test", 10.00m, "Category");

            // Act & Assert
            // Using reflection to check if Id has a setter
            var propertyInfo = typeof(Product).GetProperty("Id");
            Assert.That(propertyInfo.SetMethod, Is.Not.Null, "Id property should have a setter");
        }

        [TestCase("Electronics", true, 99.99)]
        [TestCase("Clothing", false, 29.99)]
        [TestCase("Books", true, 14.99)]
        public void Constructor_ShouldCorrectlyInitializeProduct_WithVariousValues(
            string category, bool isInStock, decimal price)
        {
            // Arrange
            int id = 1;
            string name = "Test Product";

            // Act
            var product = new Product(id, name, price, category, isInStock);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(product.Id, Is.EqualTo(id));
                Assert.That(product.Name, Is.EqualTo(name));
                Assert.That(product.Price, Is.EqualTo(price));
                Assert.That(product.Category, Is.EqualTo(category));
                Assert.That(product.IsInStock, Is.EqualTo(isInStock));
            });
        }
    }
}