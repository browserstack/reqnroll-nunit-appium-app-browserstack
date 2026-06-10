using System;
using System.Threading;
using System.Collections.ObjectModel;
using Reqnroll;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace ReqnrollAppiumBrowserStack
{
    [Binding]
    public class SampleTestSteps
    {
        private readonly AndroidDriver<AndroidElement> _driver;

        public SampleTestSteps()
        {
            _driver = AppiumHooks.ThreadLocalDriver.Value!;
        }

        [Given(@"I try to search using the Wikipedia App")]
        public void GivenITrySearchWikipediaApp()
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(
                    MobileBy.AccessibilityId("Search Wikipedia")));
            searchElement.Click();
        }

        [When(@"I search with the keyword BrowserStack")]
        public void WhenISearchKeywordBrowserStack()
        {
            AndroidElement insertTextElement = (AndroidElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(
                    By.Id("org.wikipedia.alpha:id/search_src_text")));
            insertTextElement.SendKeys("BrowserStack");
            Thread.Sleep(5000);
        }

        [Then(@"the search results should be listed")]
        public void ThenSearchResultsShouldBeListed()
        {
            ReadOnlyCollection<AndroidElement> results =
                _driver.FindElements(By.ClassName("android.widget.TextView"));
            Assert.That(results.Count, Is.GreaterThan(0));
        }
    }
}
