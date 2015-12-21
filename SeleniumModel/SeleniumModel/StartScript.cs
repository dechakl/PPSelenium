using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Xunit;
using SeleniumModel.Station1;

namespace SeleniumModel
{

    public class StartScript
    {

        [Fact]
        public void StudentPractice()
        {
            IWebDriver driver = new ChromeDriver(@"E:\temp\chromedriver_win32");

            var s = new StudentPracticeScript(driver);
            s.Run();
        }
    }
}