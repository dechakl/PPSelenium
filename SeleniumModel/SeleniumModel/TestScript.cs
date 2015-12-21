using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using NUnit.Framework;

namespace SeleniumModel
{
    public abstract class TestScript
    {
        public IWebDriver driver { get; set; }
        public string baseURL = "http://pointplus.iknow.co.th";

        public TestScript(IWebDriver driver)
        {
            this.driver = driver;
            this.driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitForElement(By byElementName)
        {
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(byElementName)) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
        }

        public void Pause(int t = 1000)
        {
            Thread.Sleep(t);
        }

        abstract public void Run();


    }
}
