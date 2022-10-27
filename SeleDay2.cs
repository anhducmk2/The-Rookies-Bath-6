using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Assert = NUnit.Framework.Assert;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;


namespace SeleDay2
{
    [TestClass]
    public class TestingScenario
    {
        // Vars
        protected WebDriverWait _wait;
        protected IWebDriver _driver;
        protected string EXPECTED_FORM_TITLE = "CUSTOMER SERVICE - CONTACT US";
        protected string EXPECTED_PAGE_TITLE = "My Store"; // typo from "Store" to "store"

        // Locators
        private By contactUsButton = By.XPath("//*[text()='Contact us']");
        private By customerServiceTitle = By.XPath("//*[contains(@class, 'page-heading')]");

        [SetUp]
        // prepare chromedriver
        public void SetUp()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Scenario1()
        {
            //
            _driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Console.WriteLine("The website is opened successfully");

            // Click to “Contact Us” link on top menu to open Contact us page
            IWebElement getContactUsButton = ReturnWebElement(contactUsButton);
            getContactUsButton.Click();

            // Verify the title of the form is “CUSTOMER SERVICE - CONTACT US”
            IWebElement getCustomerServiceTitle = ReturnWebElement(customerServiceTitle);
            Assert.That(getCustomerServiceTitle.Text, Is.EqualTo(EXPECTED_FORM_TITLE));
            Console.WriteLine("Text Box Title validated successfully");

            // Come back to Home page (Use ‘Back’ command)
            _driver.Navigate().Back();
            // Verify the title of page is “My store”
            string pageTitle = _driver.Title;
            Assert.That(pageTitle, Is.EqualTo(EXPECTED_PAGE_TITLE));
            Console.WriteLine("Text Page Title validated successfully");

            // Again go back to Contact us page (This time use ‘Forward’ command)
            _driver.Navigate().Forward();

            // Close the Browser
            _driver.Close();

        }

        // Find and click elems
        public IWebElement ReturnWebElement(By by)
        {
            IWebElement e = _driver.FindElement(by);
            _wait.Until(SeleniumExtras.WaitHelpers.
                ExpectedConditions.ElementIsVisible(by));
            return e;
        }
        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}