using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V133.Audits;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace automatenow.POM
{
    internal class Form
    {
        private readonly IWebDriver driver_;

        //Locators

        private By FormBtn = By.XPath("//a[@href='https://practice-automation.com/form-fields/']");
        private By AssertFormHead = By.XPath("//div[@class='container pt-1 pb-1']/child::*[text()='Form Fields']");
        private By AssertFormDrink = By.XPath("//label[text()='What is your favorite drink?']");
        private By NameField = By.XPath("//input[@id='name-input']");
        private By PasswordField = By.XPath("//input[@type='password']");
        private By FavouriteDrink;
        private By FavouriteColor;
        private By AutomationChoice = By.XPath("//select[@id='automation']");
        private By AutomationToolList;
        private By EmailField = By.XPath("//input[@id='email']");
        private By MessageField = By.XPath("//textarea[@id='message']");
        private By SubmitBtn = By.XPath("//button[@id='submit-btn']");

        public Form(IWebDriver driver_) 
        {
            this.driver_ = driver_;
          

        }
        public void submitform(string name_,string password_,string favdrink_,string favcolor_,string email_,string message_)
        {
            IJavaScriptExecutor scroll_ = (IJavaScriptExecutor)driver_;
            driver_.FindElement(FormBtn).Click();
            IWebElement formpagehead_ = driver_.FindElement(AssertFormHead);
            IWebElement formpagedrink_ = driver_.FindElement(AssertFormDrink);

            string formpageheadtext_ = formpagehead_.Text;
            string formpagedrinktext_ = formpagedrink_.Text; 
            
            Assert.AreEqual("Form Fields", formpageheadtext_, "Error in Form page");
            driver_.FindElement(NameField).SendKeys(name_);
            driver_.FindElement(PasswordField).SendKeys(password_);
            //Assert.AreEqual("Form Fields", formpageheadtext_, "Error in Form page");
            scroll_.ExecuteScript("window.scrollBy(0,200)");
            Assert.AreEqual("What is your favorite drink?", formpagedrinktext_, "Error for drink");
            selectdrink(favdrink_);
            FavouriteColor = By.XPath("//label[text()='" + favcolor_ + "']/preceding-sibling::input[@name='fav_color']");
            scroll_.ExecuteScript("window.scrollBy(0,250)");
            driver_.FindElement(FavouriteColor).Click();
            automationchoice("yes");
            scroll_.ExecuteScript("window.scrollBy(0,250)");
            driver_.FindElement(EmailField).SendKeys(email_);
            scroll_.ExecuteScript("window.scrollBy(0,250)");
            driver_.FindElement(MessageField).SendKeys(message_);
            Thread.Sleep(8000);
            scroll_.ExecuteScript("window.scrollBy(0,250)");
            driver_.FindElement(SubmitBtn).Click();

        }
        public void selectdrink(string favdrink_)
        {

            FavouriteDrink = By.XPath("//label[text()='" + favdrink_ + "']/preceding-sibling::input[@name='fav_drink']");
            driver_.FindElement(FavouriteDrink).Click();
            
        }
        public void automationchoice(string choice_)
        {
            IWebElement dropdown_ = driver_.FindElement(AutomationChoice);
            SelectElement selectchoice_ = new SelectElement(dropdown_);

            selectchoice_.SelectByValue(choice_);
        }
        public void automationtools()
        {
            int i = 1;
            string tool_;
            while (true)
            {
                if (i > 5)
                {
                    break;
                }
                else
                {
                    AutomationToolList = By.XPath("(//label[text()='Automation tools']/following::ul/child::li)[" + i + "]");
                    tool_ = driver_.FindElement(AutomationToolList).Text;
                    Console.WriteLine(tool_);
                    ++i;

                }
            }
        }
    }
}
