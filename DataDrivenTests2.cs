using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DataDrivenWebDriverTests
{
    public class DataDrivenTests2
    {
        private WebDriver driver;
        private const string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

        IWebElement firstInput;
        IWebElement operationField;
        IWebElement secondInput;
        IWebElement resultField;
        IWebElement calcButton;
        IWebElement resetButton;

          
        [OneTimeSetUp]
        public void Setup() 
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = BaseUrl;

            firstInput = driver.FindElement(By.Id("number1"));
            operationField = driver.FindElement(By.Id("operation"));
            secondInput = driver.FindElement(By.Id("number2"));
            resultField = driver.FindElement(By.Id("result"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }

        [Test]
        public void Test_Sum_TwoPositiveNumbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10");
            operationField.SendKeys("+");
            secondInput.SendKeys("2");

            // Act
            calcButton.Click();

            // Assert
            var expectedResult = "Result: 12";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Sum_TwoNegativeNumbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("-10");
            operationField.SendKeys("+");
            secondInput.SendKeys("-2");

            // Act
            calcButton.Click();

            // Assert
           var expectedResult = "Result: -12";
           Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Multiply_TwoPositiveNumbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10");
            operationField.SendKeys("*");
            secondInput.SendKeys("2");

            // Act
            calcButton.Click();

            // Assert
            var expectedResult = "Result: 20";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Multiply_TwoNegativeNumbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("-10");
            operationField.SendKeys("*");
            secondInput.SendKeys("-2");

            // Act
            calcButton.Click();

            // Assert
            var expectedResult = "Result: 20";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Substract_TwoPositiveNumbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("10");
            operationField.SendKeys("-");
            secondInput.SendKeys("2");

            // Act
            calcButton.Click();

            // Assert
            var expectedResult = "Result: 8";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }

        [Test]
        public void Test_Substract_TwoNegativeNumbers()
        {
            // Arrange
            resetButton.Click();
            firstInput.SendKeys("-10");
            operationField.SendKeys("-");
            secondInput.SendKeys("-2");

            // Act
            calcButton.Click();

            // Assert
            var expectedResult = "Result: -8";
            Assert.That(expectedResult, Is.EqualTo(resultField.Text));
        }
    }
}