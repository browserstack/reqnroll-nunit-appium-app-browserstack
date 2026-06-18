using System;
using System.Threading;
using System.Collections.ObjectModel;
using Reqnroll;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace ReqnrollAppiumBrowserStack
{
    [Binding]
    public class SampleLocalTestSteps
    {
        private readonly AndroidDriver<AndroidElement> _driver;

        public SampleLocalTestSteps()
        {
            _driver = AppiumHooks.ThreadLocalDriver.Value!;
        }

        [Given(@"I start the test on the Local Sample App")]
        public void GivenIStartTestOnLocalApp()
        {
            AndroidElement testAction = (AndroidElement)new WebDriverWait(_driver, TimeSpan.FromSeconds(30))
                .Until(ExpectedConditions.ElementToBeClickable(
                    By.Id("com.example.android.basicnetworking:id/test_action")));
            testAction.Click();
        }

        [Then(@"I should see the connection is up and running")]
        public void ThenIShouldSeeUpAndRunning()
        {
            Thread.Sleep(5000);
            ReadOnlyCollection<AndroidElement> textViews =
                _driver.FindElements(By.ClassName("android.widget.TextView"));

            bool found = false;
            foreach (AndroidElement element in textViews)
            {
                if (element.Text != null && element.Text.Contains("The active connection is"))
                {
                    found = true;
                    break;
                }
            }
            Assert.That(found, Is.True, "Expected the Local Sample App to report an active connection");
        }
    }
}
