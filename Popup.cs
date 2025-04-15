using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatenow.POM
{
    internal class Popup
    {
        private readonly IWebDriver driver_;
        private By PopupBtn = By.XPath("//a[@href='https://practice-automation.com/popups/']");
        private By AssertPopupPage = By.XPath("//div[@class='container pt-1 pb-1']/child::*[text()='Popups']");
        private By AlertPopupBtn = By.XPath("(//button[@class='custom_btn btn_hover']/child::b)[1]");
        private By ConfirmPopupBtn = By.XPath("(//button[@class='custom_btn btn_hover']/child::b)[2]");
        private By PromptPopupBtn = By.XPath("(//button[@class='custom_btn btn_hover']/child::b)[3]");
        private By HeaderTitle = By.XPath("//strong[text()='Welcome to your software automation practice website! ']");


        public Popup(IWebDriver driver_)
        {
            this.driver_ = driver_; 
        }
        public void popup()
        {
            string asserthometext_ = driver_.FindElement(HeaderTitle).Text;
            string assertpopuppage_;
            IJavaScriptExecutor scroll_ = (IJavaScriptExecutor)driver_;

            IAlert alert_; //= driver_.SwitchTo().Alert();
            IAlert promptalert_; //= driver_.SwitchTo().Alert();

            Assert.AreEqual("Welcome to your software automation practice website!",asserthometext_, "Error");
            scroll_.ExecuteScript("window.scrollBy(0,400)");
            Thread.Sleep(2000);
            driver_.FindElement(PopupBtn).Click();
            Thread.Sleep(2000);
            assertpopuppage_= driver_.FindElement(AssertPopupPage).Text;
            Assert.AreEqual("Popups", assertpopuppage_, "Error!!");
            driver_.FindElement(AlertPopupBtn).Click();
            alert_ = driver_.SwitchTo().Alert();
            alert_.Accept();
            Assert.AreEqual("Popups", assertpopuppage_, "Error!!");
            driver_.FindElement(ConfirmPopupBtn).Click();
            alert_ = driver_.SwitchTo().Alert();
            alert_.Accept();
            Assert.AreEqual("Popups", assertpopuppage_, "Error!!");
            driver_.FindElement(PromptPopupBtn).Click();
            promptalert_ = driver_.SwitchTo().Alert();
            promptalert_.SendKeys("The wolrd is happy place");
            promptalert_.Accept();
            Thread.Sleep(10000);
                      
        }

    }
}
