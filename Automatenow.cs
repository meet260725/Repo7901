using automatenow.POM;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V132.Network;
using OpenQA.Selenium.Support.UI;
using System.ComponentModel;

namespace automatenow
{
    public class Automatenow
      {

        private By HomeBtn = By.XPath("//a[@href='https://practice-automation.com/' and text()='Home']");
        private By HeaderTitle = By.XPath("//strong[text()='Welcome to your software automation practice website! ']");
        IWebDriver driver_;
        private Delay delay_Obj;
        private Form form_Obj;
        private Popup popup_Obj;
        private Calendars calendars_Obj;
        private Modals modals_Obj;


        [SetUp]
        public void Setup()
        {
            driver_ = new ChromeDriver();
            driver_.Navigate().GoToUrl("https://practice-automation.com/");
            driver_.Manage().Window.Maximize();

            delay_Obj = new Delay(driver_);
            form_Obj = new Form(driver_);
            popup_Obj = new Popup(driver_);
            calendars_Obj = new Calendars(driver_);
           modals_Obj = new Modals(driver_);

        }

        [Test]
        public void Test1()
        { string msg = "Happy Birthday! Wishing you a day filled with love, laughter, and unforgettable memories. Have an amazing year ahead!";

            IJavaScriptExecutor scroll_ = (IJavaScriptExecutor)driver_;
            IWebElement header_ = driver_.FindElement(HeaderTitle);
            
            string headertext_ = header_.Text;
            

            Assert.That(headertext_, Is.EqualTo("Welcome to your software automation practice website!"));
            //action_.ScrollToElement(driver_.FindElement(DelayBtn));
            scroll_.ExecuteScript("window.scrollBy(0,500)");
            delay_Obj.delays();
            //driver_.FindElement(HomeBtn).Click();
            //Assert.AreEqual("Welcome to your software automation practice website!", headertext_, "Error");
            scroll_.ExecuteScript("window.scrollBy(0,500)");
            Thread.Sleep(2000);
            //submitform(string name_,string password_,string favdrink_,string favcolor_,string email_,string message_)
            form_Obj.submitform("Siddharth", "sid@123456", "Water", "Red", "sid234@yopmail.com", msg);

        }
        [Test] public void Test2() 
        {
            IJavaScriptExecutor scroll_ = (IJavaScriptExecutor)driver_;
            IWebElement header_ = driver_.FindElement(HeaderTitle);

            string headertext_ = header_.Text;

            scroll_.ExecuteScript("window.scrollBy(0,400)");
            Assert.AreEqual("Welcome to your software automation practice website!", headertext_, "Error");
            popup_Obj.popup();
        }
        [Test]
        public void TestCalander()
        {
            IJavaScriptExecutor scroll_ = (IJavaScriptExecutor)driver_;
            IWebElement header_ = driver_.FindElement(HeaderTitle);

            string headertext_ = header_.Text;


            Assert.AreEqual("Welcome to your software automation practice website!", headertext_, "Error");
            calendars_Obj.calendar("30", "April", "2025");
        }
        [Test]
        public void TestModals()
        {
           // IJavaScriptExecutor scroll_ = (IJavaScriptExecutor)driver_;
            IWebElement header_ = driver_.FindElement(HeaderTitle);

            string headertext_ = header_.Text;

            Thread.Sleep(2000);
            Assert.AreEqual("Welcome to your software automation practice website!", headertext_, "Error");
            //modalsection(string name_,string email_,string message_)
            modals_Obj.modalsection("Saurabh", "saurabh234@yopmail.com", "Good morning");
        }
        [Test]
        public void TestTable()
        {
            WebDriverWait wait = new WebDriverWait(driver_, TimeSpan.FromSeconds(10));
            //wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Form Fields']"))).Click();
        }
        [TearDown]
        public void Teardown()
        {
            driver_.Dispose();
   

        }
    }
}