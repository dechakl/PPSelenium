using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using NUnit.Framework;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;
using System.Threading;

namespace SeleniumModel.Station1
{
    public class StudentPracticeScript : TestScript
    {
        public StudentPracticeScript(IWebDriver driver)
            : base(driver)
        {
        }
               
        
        public override void Run()
        {
            try
            {
                driver.Navigate().GoToUrl(baseURL + "/LoginPage.aspx");

                Pause(2000);
                WaitForElement(By.Id("sb-overlay"));
                driver.FindElement(By.XPath("//*[@id=\"sb-nav-close\"]")).Click();

                Pause();
                driver.FindElement(By.XPath("//*[@id=\"btnPractice\"]")).Click();
                Assert.Equal("http://pointplus.iknow.co.th/PracticeMode_Pad/MainPractice.aspx", driver.Url);
                driver.FindElement(By.Id("BtnBack")).Click();

                Pause(2000);
                WaitForElement(By.Id("sb-overlay"));
                driver.FindElement(By.XPath("//*[@id=\"sb-nav-close\"]")).Click();
                Assert.Equal("http://pointplus.iknow.co.th/Loginpage.aspx", driver.Url);

                Pause(2000);
                driver.FindElement(By.XPath("//*[@id=\"btnPractice\"]")).Click();

                driver.FindElement(By.Id("tdMainPractice")).Click();
                Assert.True(Regex.IsMatch(driver.Url, "^http://pointplus\\.iknow\\.co\\.th/PracticeMode_Pad/ChooseClass\\.aspx[\\s\\S]UseComputer=1&DashboardMode=6$"));
                driver.FindElement(By.Id("ctl00_MainContent_5f4765db-0917-470b-8e43-6d1c7b030818")).Click();
                Assert.Equal("http://pointplus.iknow.co.th/PracticeMode_Pad/ChooseSubject.aspx", driver.Url);

                Pause(2000);
                driver.FindElement(By.Id("ctl00_MainContent_fda224d9-cebe-4642-acd0-d7f7282e36ae")).Click();
                Assert.Equal("http://pointplus.iknow.co.th/PracticeMode_Pad/ChooseQuestionset.aspx", driver.Url);

                Pause(2000);

                driver.FindElement(By.XPath("//*[@id=\"3cb8d08b-5ec4-4929-8ab2-0eee6b0acc2c\"]")).Click();
                Pause();
                driver.FindElement(By.Id("play_3cb8d08b-5ec4-4929-8ab2-0eee6b0acc2c")).Click();


                Pause(12000);
                Assert.True(Regex.IsMatch(driver.Url, "^http://pointplus\\.iknow\\.co\\.th/Activity/ActivityPage\\.aspx[\\s\\S]TestsetID=8932f2b9-fb0a-46e1-be84-abb7148e0d90$"));

                driver.FindElement(By.Id("btnNextTop")).Click();
                WaitForElement(By.Id("lblNoExam"));

                Assert.Equal("2 / 5", driver.FindElement(By.XPath("//span[@id='lblNoExam']")).Text);
                driver.FindElement(By.Id("btnPrvTop")).Click();
                Assert.Equal("1 / 5", driver.FindElement(By.XPath("//span[@id='lblNoExam']")).Text);
                driver.FindElement(By.Id("lblNoExam")).Click();
                Assert.True(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='divMenuTopNextPre']")).GetAttribute("style"), "^[\\s\\S]*display: none[\\s\\S]*$"));
                Assert.True(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='divNextPre']")).GetAttribute("style"), "^[\\s\\S]*display: block[\\s\\S]*$"));

                Pause(2000);
                Assert.Equal("1 / 5", driver.FindElement(By.Id("lblRunNoExam")).Text);
                driver.FindElement(By.Id("btnNext")).Click();
                Assert.Equal("2 / 5", driver.FindElement(By.Id("lblRunNoExam")).Text);
                driver.FindElement(By.Id("btnPrevious")).Click();
                Assert.Equal("1 / 5", driver.FindElement(By.Id("lblRunNoExam")).Text);
                driver.FindElement(By.Id("imgRun")).Click();

                Pause(2000);
                Assert.True(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='divNextPre']")).GetAttribute("style"), "^[\\s\\S]*display: none[\\s\\S]*$"));
                driver.FindElement(By.Id("btnNextTop")).Click();
                driver.FindElement(By.Id("btnNextTop")).Click();
                driver.FindElement(By.Id("btnNextTop")).Click();
                driver.FindElement(By.Id("btnNextTop")).Click();
                driver.FindElement(By.Id("btnNextTop")).Click();

                Pause(2000);
                Assert.Equal("จบฝึกฝนเลยหรือจะทบทวนอีกสักรอบก่อนคะ", driver.FindElement(By.Id("ui-dialog-title-LinkDialog")).Text);
                driver.FindElement(By.XPath("(//button[@type='button'])[4]")).Click();

                driver.FindElement(By.Id("btnNextTop")).Click();
                Pause(2000);
                Assert.Equal("จบฝึกฝนเลยหรือจะทบทวนอีกสักรอบก่อนคะ", driver.FindElement(By.Id("ui-dialog-title-LinkDialog")).Text);
                driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
                Pause(2000);
                driver.FindElement(By.Id("btnSlideMenu")).Click();
                driver.FindElement(By.Id("imgSetting1")).Click();
                driver.FindElement(By.CssSelector("a[title=\"จบกิจกรรม\"] > span")).Click();

                Pause(2000);
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                driver.FindElement(By.Id("BtnPracticeFromComputer")).Click();

                Pause(2000);
                driver.FindElement(By.XPath("//*[@id=\"3cb8d08b-5ec4-4929-8ab2-0eee6b0acc2c\"]")).Click();
                Pause();
                driver.FindElement(By.Id("play_3cb8d08b-5ec4-4929-8ab2-0eee6b0acc2c")).Click();

                Pause(13000);
                String a = "คำว่า “สติ” คืออะไร";
                String b = driver.FindElement(By.Id("mainQuestion")).Text;

                bool isQuestion = false;
                while (!isQuestion)
                {
                    if (b.IndexOf(a) > 0)
                    {
                        driver.FindElement(By.XPath("//*[@answerid=\"82fcfd84-4ed2-4b80-a820-6bb501890ada\"]")).Click();
                        isQuestion = true;
                        break;
                    }
                    else
                    {
                        driver.FindElement(By.Id("btnNextTop")).Click();
                        Pause(2000);
                        b = driver.FindElement(By.Id("mainQuestion")).Text;
                    }
                }


                driver.FindElement(By.Id("imgSetting1")).Click();
                driver.FindElement(By.CssSelector("a[title=\"จบกิจกรรม\"] > span")).Click();
                driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();

                Pause(2000);
                Assert.Equal("ได้คะแนน 1 / 5 ค่ะ", driver.FindElement(By.CssSelector("div.OrangeBack > div")).Text);

                driver.FindElement(By.Id("btnSlideMenu")).Click();

                Pause(2000);
                driver.FindElement(By.Id("btnSlideMenu")).Click();

                Pause(2000);
                driver.FindElement(By.XPath("//*[@noquestion=\"5\"]")).Click();
                driver.FindElement(By.Id("btnPrvTop")).Click();
                driver.FindElement(By.Id("btnPrvTop")).Click();
                driver.FindElement(By.Id("btnPrvTop")).Click();
                driver.FindElement(By.Id("btnPrvTop")).Click();
                driver.FindElement(By.Id("imgSetting1")).Click();
                driver.FindElement(By.CssSelector("a[title=\"จบกิจกรรม\"] > span")).Click();
                driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Click();
                driver.FindElement(By.CssSelector("a[title=\"จบกิจกรรม\"] > span")).Click();
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                driver.FindElement(By.Id("BtnReview")).Click();

                Pause(2000);
                driver.FindElement(By.Id("btnSlideMenu")).Click();
                driver.FindElement(By.Id("imgSetting1")).Click();

                Pause(2000);
                driver.FindElement(By.CssSelector("a[title=\"จบกิจกรรม\"] > span")).Click();
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                driver.FindElement(By.Id("BtnPracticeFromComputer")).Click();
                driver.FindElement(By.LinkText("เลือกชั้น -->")).Click();
                driver.FindElement(By.Id("ctl00_MainContent_e5dbfa06-c4ce-4ce2-9f47-60e9cb99a38c")).Click();
                driver.FindElement(By.Id("ctl00_MainContent_fda224d9-cebe-4642-acd0-d7f7282e36ae")).Click();


                Pause(2000);
                driver.FindElement(By.XPath("//*[@id=\"3d89fcf6-333a-4cfe-a16f-8a508a566da9\"]")).Click();
                Pause();
                driver.FindElement(By.Id("play_3d89fcf6-333a-4cfe-a16f-8a508a566da9")).Click();

                Pause(13000);
                driver.FindElement(By.XPath("//table[@id='Table1']/tbody/tr[2]/td[2]")).Click();
                driver.FindElement(By.Id("imgSetting1")).Click();
                driver.FindElement(By.CssSelector("a[title=\"จบกิจกรรม\"] > span")).Click();
                driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();

                Pause(2000);
                driver.FindElement(By.Id("btnSlideMenu")).Click();

                Pause(2000);
                driver.FindElement(By.Id("btnQuestionExp")).Click();
                driver.FindElement(By.Id("imgSetting1")).Click();

                Pause(2000);
                driver.FindElement(By.CssSelector("a[title=\"จบกิจกรรม\"] > span")).Click();
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
                driver.FindElement(By.Id("BtnPracticeFromComputer")).Click();

                
            }
            catch
            {
                Assert.True(false);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
            
        }
    }
}
