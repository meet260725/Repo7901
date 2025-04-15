using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatenow.POM
{
    internal class Modals
    {
        private readonly IWebDriver driver_;
        private By ModalBtn = By.XPath("//a[@href='https://practice-automation.com/modals/']");
        private By AssertModalPage = By.XPath("//div[@class='container pt-1 pb-1']/child::*[text()='Modals']");
        private By SimpleModalBtn = By.XPath("//div[@class='entry-content']/button[@id='simpleModal']");
        private By SimpleTabCloseBtn = By.XPath("(//button[@class='pum-close popmake-close' and @aria-label='Close'])[2]");
        private By FormModalBtn = By.XPath("//button[@id='formModal']");
        private By NameInput = By.XPath("//input[@id='g1051-name']");
        private By EmailInput = By.XPath("//input[@id='g1051-email']");
        private By MessageInput = By.XPath("//textarea[@id='contact-form-comment-g1051-message']");


        public Modals(IWebDriver driver_) 
        {
            this.driver_ = driver_; 
        } 
        public void modalsection(string name_,string email_,string message_)
        {
            
            Thread.Sleep(2000);
            IJavaScriptExecutor scroll_ = (IJavaScriptExecutor)driver_;
            scroll_.ExecuteScript("window.scrollBy(0,400)");
            Thread.Sleep(2000);
            driver_.FindElement(ModalBtn).Click();
            string modalpagehead_ = driver_.FindElement(AssertModalPage).Text;

            Assert.AreEqual(expected: "Modals", actual: modalpagehead_, message: "Error!!");
            Thread.Sleep(1000);
            driver_.FindElement(SimpleModalBtn).Click();
            Thread.Sleep(1500);
            driver_.FindElement(SimpleTabCloseBtn).Click();
            scroll_.ExecuteScript("window.scrollBy(0,500)");
            Thread.Sleep(3500);

            driver_.FindElement(FormModalBtn).Click();
            Thread.Sleep(1500);
            driver_.FindElement(NameInput).SendKeys(name_);
            driver_.FindElement(EmailInput).SendKeys(email_);
            driver_.FindElement(MessageInput).SendKeys(message_);
            Thread.Sleep(2000);
            scroll_.ExecuteScript("window.scrollBy(0,600)");
                

        }
    }
}
