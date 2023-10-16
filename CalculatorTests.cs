using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Runtime.CompilerServices;

namespace AppiumCalculatorTests
{
    public class CalculatorTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\Others\Kursove\QA Courses Exams\Frontend QA Course\Appium Desktop\04.Appium-Desktop-Testing-Resources\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;  

        [OneTimeSetUp]
        public void OpenApplication()
        {
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement> (new Uri(appiumServer), appiumOptions); 
        }

        [OneTimeTearDown]
        public void CloseApplication()
        {
            driver.Quit();
        }

        [Test]

        public void Test_Sum_TwoPositiveNumbers()
        {
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstField.Clear();
            secondField.Clear();
            firstField.SendKeys("8");
            secondField.SendKeys("5");
            calcButton.Click();

            Assert.That(resultField.Text, Is.EqualTo("13"));  

        }
        [Test]

        public void Test_Sum_InvalidNumbers()
        {
            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstField.Clear();
            secondField.Clear();
            firstField.SendKeys("8");
            secondField.SendKeys("bfbfbf");
            calcButton.Click();

            Assert.That(resultField.Text, Is.EqualTo("error"));

        }
    }
}