using System;
using System.Threading;
using Reqnroll;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace ReqnrollAppiumBrowserStack
{
    // Manages the Appium Android driver lifecycle for each scenario.
    //
    // The driver is created with an EMPTY AppiumOptions object against the
    // BrowserStack hub. The BrowserStack SDK (BrowserStack.TestAdapter)
    // intercepts the Appium driver construction and injects the app, device,
    // and bstack:options capabilities from android/browserstack.yml — no
    // capabilities are hardcoded here.
    [Binding]
    public class AppiumHooks
    {
        // Shared with the step definitions for the current scenario.
        public static ThreadLocal<AndroidDriver<AndroidElement>> ThreadLocalDriver =
            new ThreadLocal<AndroidDriver<AndroidElement>>();

        [BeforeScenario(Order = 0)]
        public static void Initialize()
        {
            AppiumOptions appiumOptions = new AppiumOptions();
            ThreadLocalDriver.Value = new AndroidDriver<AndroidElement>(
                new Uri("https://hub-cloud.browserstack.com/wd/hub/"), appiumOptions);
        }

        [AfterScenario]
        public static void TearDown()
        {
            if (ThreadLocalDriver.IsValueCreated)
            {
                ThreadLocalDriver.Value?.Quit();
            }
        }
    }
}
