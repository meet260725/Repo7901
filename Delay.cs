using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V132.Network;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace automatenow.POM
{
    internal class Delay
    {
        private readonly IWebDriver driver_;

        //Locators
        private By DelayBtn = By.XPath("//a[@href='https://practice-automation.com/javascript-delays/']");
        private By StartBtn = By.XPath("//button[@id='start' and @onclick='delayFunc()']");
        private By DelayTimer = By.XPath("//button[@id='start' and @onclick='delayFunc()']/following::div[@id='delay']");
        private By DelayPageText = By.XPath("//a[@href='https://automatenow.io/about/']");
        private By HomeBtn = By.XPath("//a[@href='https://practice-automation.com/' and text()='Home']");

        public Delay(IWebDriver driver_) 
        {
            this.driver_ = driver_;
        }
        public void delays()
        {
            //Actions action_ = new Actions(driver_);
            IWebElement delaypage_ = driver_.FindElement(DelayPageText);
            string delaypagetext_ = delaypage_.Text;
            IJavaScriptExecutor scroll_ = (IJavaScriptExecutor)driver_;
            
            Thread.Sleep(2000);
            driver_.FindElement(DelayBtn).Click();

            //action_.ScrollToElement(driver_.FindElement(StartBtn));
            
            scroll_.ExecuteScript("window.scrollBy(0,400)");
            Thread.Sleep(2000);
            Assert.AreEqual("About", delaypagetext_, "Error");
            driver_.FindElement(StartBtn).Click();
            
            
            while (true) {
            string timertext = driver_.FindElement(DelayTimer).Text;
            if (timertext =="Liftoff!")
            {
                    Console.WriteLine("This is IF");
                    Thread.Sleep(4000);
                    driver_.FindElement(StartBtn).Click();
                    Thread.Sleep(10000);
                    scroll_.ExecuteScript("window.scrollBy(0,-500)");
                    Thread.Sleep(4000);
                    driver_.FindElement(HomeBtn).Click();
                    break;
            }
            else
            {
                continue;
            }
            }
        }

    }
}
