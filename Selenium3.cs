using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;

namespace SeleniumSession3
{
    [TestFixture]
    public class Selenium3
    {
        protected IWebDriver driver;
        protected WebDriverWait? wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void Test()
        {
            driver.Navigate().GoToUrl("http://google.com");
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//input[@name=\"q\"]")).SendKeys("selenium");
            driver.FindElement(By.XPath("//input[@name=\"btnK\"]")).SendKeys(Keys.Enter);

            string actualTL = driver.Title;
            string expectedTL = "selenium";

            Assert.That(actualTL, Is.EqualTo(expectedTL));

            driver.FindElement(By.TagName("h3")).SendKeys(Keys.Enter);

            driver.Close();
            driver.Quit();

        }
    }
}