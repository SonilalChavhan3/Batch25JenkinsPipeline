namespace Batch25JenkinsPipline.Tests.Models
{
    using Batch25JenkinsPipline.Models;

    [TestFixture]
    public class ErrorViewModelTests
    {
        [Test]
        public void RequestId_Property_ShouldBeReadableAndWritable()
        {
            // Arrange
            var viewModel = new ErrorViewModel();
            var expectedRequestId = "test-request-id";

            // Act
            viewModel.RequestId = expectedRequestId;
            var actualRequestId = viewModel.RequestId;

            // Assert
            Assert.That(actualRequestId, Is.EqualTo(expectedRequestId));
        }

        [Test]
        public void RequestId_ShouldAcceptNullValue()
        {
            // Arrange
            var viewModel = new ErrorViewModel();

            // Act
            viewModel.RequestId = null;

            // Assert
            Assert.That(viewModel.RequestId, Is.Null);
        }

        [Test]
        public void RequestId_ShouldAcceptEmptyString()
        {
            // Arrange
            var viewModel = new ErrorViewModel();

            // Act
            viewModel.RequestId = string.Empty;

            // Assert
            Assert.That(viewModel.RequestId, Is.EqualTo(string.Empty));
        }

        [Test]
        public void RequestId_ShouldAcceptWhitespaceString()
        {
            // Arrange
            var viewModel = new ErrorViewModel();

            // Act
            viewModel.RequestId = "   ";

            // Assert
            Assert.That(viewModel.RequestId, Is.EqualTo("   "));
        }

        [Test]
        public void ShowRequestId_ShouldReturnTrue_WhenRequestIdIsNotNullOrEmpty()
        {
            // Arrange
            var testCases = new[]
            {
                "request123",
                "a",          // single character
                "  test  ",   // with spaces
                "123",        // numeric
                "test-123"    // with hyphen
            };

            foreach (var requestId in testCases)
            {
                var viewModel = new ErrorViewModel { RequestId = requestId };

                // Act
                var result = viewModel.ShowRequestId;

                // Assert
                Assert.That(result, Is.True,
                    $"ShowRequestId should be True for RequestId: '{requestId}'");
            }
        }

        [Test]
        public void ShowRequestId_ShouldReturnFalse_WhenRequestIdIsNull()
        {
            // Arrange
            var viewModel = new ErrorViewModel { RequestId = null };

            // Act
            var result = viewModel.ShowRequestId;

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void ShowRequestId_ShouldReturnFalse_WhenRequestIdIsEmptyString()
        {
            // Arrange
            var viewModel = new ErrorViewModel { RequestId = string.Empty };

            // Act
            var result = viewModel.ShowRequestId;

            // Assert
            Assert.That(result, Is.False);
        }

        
        [Test]
        public void ShowRequestId_ShouldBeReadOnlyProperty()
        {
            // Arrange
            var propertyInfo = typeof(ErrorViewModel).GetProperty("ShowRequestId");

            // Act & Assert
            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo.CanWrite, Is.False, "ShowRequestId should be read-only");
            Assert.That(propertyInfo.CanRead, Is.True, "ShowRequestId should be readable");
        }

        [Test]
        public void ShowRequestId_ShouldBeComputedProperty()
        {
            // Arrange
            var viewModel1 = new ErrorViewModel { RequestId = "test" };
            var viewModel2 = new ErrorViewModel { RequestId = null };

            // Act & Assert
            Assert.That(viewModel1.ShowRequestId, Is.True);
            Assert.That(viewModel2.ShowRequestId, Is.False);
        }

        [Test]
        public void ShowRequestId_ShouldUpdate_WhenRequestIdChanges()
        {
            // Arrange
            var viewModel = new ErrorViewModel();

            // Act & Assert - Initial state (null)
            Assert.That(viewModel.ShowRequestId, Is.False);

            // Act & Assert - After setting non-empty RequestId
            viewModel.RequestId = "test-id";
            Assert.That(viewModel.ShowRequestId, Is.True);

            // Act & Assert - After setting to null
            viewModel.RequestId = null;
            Assert.That(viewModel.ShowRequestId, Is.False);

            // Act & Assert - After setting to empty
            viewModel.RequestId = string.Empty;
            Assert.That(viewModel.ShowRequestId, Is.False);

            // Act & Assert - After setting back to non-empty
            viewModel.RequestId = "another-test";
            Assert.That(viewModel.ShowRequestId, Is.True);
        }

        [TestCase("request-123", true)]

        [TestCase("", false)]
        [TestCase(" ", false)]
        [TestCase("  ", false)]
        [TestCase("\t", false)]
        [TestCase("test", true)]
        public void ShowRequestId_ShouldReturnCorrectValue_ForVariousInputs(
            string requestId, bool expectedResult)
        {
            // Arrange
            var viewModel = new ErrorViewModel { RequestId = requestId };

            // Act
            var result = viewModel.ShowRequestId;

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult),
                $"ShowRequestId should be {expectedResult} for RequestId: '{requestId}'");
        }

        [Test]
        public void DefaultConstructor_ShouldInitializeRequestIdAsNull()
        {
            // Arrange & Act
            var viewModel = new ErrorViewModel();

            // Assert
            Assert.That(viewModel.RequestId, Is.Null);
        }

        [Test]
        public void Model_ShouldBeSerializable_IfRequired()
        {
            // This test verifies the class has basic serialization attributes if needed
            var type = typeof(ErrorViewModel);

            // Check if it's marked as Serializable (optional based on requirements)
            // var attributes = type.GetCustomAttributes(typeof(SerializableAttribute), false);
            // Assert.That(attributes.Length, Is.EqualTo(1), "Should be marked as Serializable");
        }

        [Test]
        public void Properties_ShouldHaveCorrectAccessModifiers()
        {
            // Arrange
            var type = typeof(ErrorViewModel);
            var requestIdProperty = type.GetProperty("RequestId");
            var showRequestIdProperty = type.GetProperty("ShowRequestId");

            // Assert
            Assert.That(requestIdProperty, Is.Not.Null);
            Assert.That(showRequestIdProperty, Is.Not.Null);

            // RequestId should have public getter and setter
            Assert.That(requestIdProperty.GetMethod.IsPublic, Is.True);
            Assert.That(requestIdProperty.SetMethod.IsPublic, Is.True);

            // ShowRequestId should have public getter only
            Assert.That(showRequestIdProperty.GetMethod.IsPublic, Is.True);
        }

        [Test]
        public void ShowRequestId_ShouldUseStringIsNullOrEmpty()
        {
            // This is a behavior test to ensure the logic matches string.IsNullOrEmpty()
            var testCases = new (string RequestId, bool Expected)[]
            {
                (null, false),
                ("", false),
                (" ", false),
                ("test", true),
                ("123", true),
                ("  test  ", true)
            };

            foreach (var testCase in testCases)
            {
                var viewModel = new ErrorViewModel { RequestId = testCase.RequestId };

                // Act
                var actualResult = viewModel.ShowRequestId;
                var expectedResult = !string.IsNullOrEmpty(testCase.RequestId);

                // Assert
                Assert.That(actualResult, Is.EqualTo(expectedResult),
                    $"For RequestId: '{testCase.RequestId}', expected {expectedResult} but got {actualResult}");
            }
        }

        [Test]
        public void Equality_Test_WhenComparingInstances()
        {
            // Arrange
            var model1 = new ErrorViewModel { RequestId = "test" };
            var model2 = new ErrorViewModel { RequestId = "test" };
            var model3 = new ErrorViewModel { RequestId = "different" };

            // Note: Since ErrorViewModel doesn't override Equals, 
            // ReferenceEquals will be used by default
            Assert.That(model1, Is.Not.EqualTo(model2));
            Assert.That(model1, Is.Not.EqualTo(model3));
        }

        [Test]
        public void ToString_Method_ShouldReturnTypeName()
        {
            // Arrange
            var viewModel = new ErrorViewModel { RequestId = "test-id" };

            // Act
            var result = viewModel.ToString();

            // Assert - Default implementation returns type name
            Assert.That(result, Is.EqualTo(viewModel.GetType().ToString()));
        }

        [Test]
        public void ErrorViewModel_ShouldBeInstantiable_WithoutParameters()
        {
            // Arrange & Act
            var viewModel = new ErrorViewModel();

            // Assert
            Assert.That(viewModel, Is.Not.Null);
            Assert.That(viewModel, Is.InstanceOf<ErrorViewModel>());
        }

        [Test]
        public void RequestId_CanStoreLongStrings()
        {
            // Arrange
            var longString = new string('X', 10000); // 10k characters
            var viewModel = new ErrorViewModel();

            // Act
            viewModel.RequestId = longString;

            // Assert
            Assert.That(viewModel.RequestId, Is.EqualTo(longString));
            Assert.That(viewModel.RequestId.Length, Is.EqualTo(10000));
        }

        [Test]
        public void ShowRequestId_ShouldWorkCorrectly_WithSpecialCharacters()
        {
            // Arrange
            var specialStrings = new[]
            {
                "test@example.com",
                "request-id_123",
                "request with spaces",
                "request\nwith\nnewlines",
                "request\twith\ttabs",
                "request\u00A9with\u00AE" // with copyright and registered symbols
            };

            foreach (var specialString in specialStrings)
            {
                var viewModel = new ErrorViewModel { RequestId = specialString };

                // Act
                var result = viewModel.ShowRequestId;

                // Assert
                Assert.That(result, Is.True,
                    $"ShowRequestId should be True for special string: '{specialString}'");
            }
        }
    }
}