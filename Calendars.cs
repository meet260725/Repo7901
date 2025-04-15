using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatenow.POM
{
    internal class Calendars
    {
        private readonly IWebDriver driver_;
        //Locators
        private By CalendarBtn = By.XPath("//div[@class='wp-block-button has-custom-width wp-block-button__width-50 is-style-shadow']/child::a[text()='Calendars']");
        private By CalenderField = By.XPath("//input[@id='g1065-2-1-selectorenteradate']");
        private By AssertCalendarPage = By.XPath("//div[@class='container pt-1 pb-1']/child::*[text()='Calendars']");
        private By CalendarNextBtn = By.XPath("//a[@class='ui-datepicker-next ui-corner-all']");
        private By CalendarPreBtn = By.XPath("//a[@class='ui-datepicker-prev ui-corner-all']");
        private By CalendarDate;
        private By CalenderMonth;
        private By CalenderYear;
        public Calendars(IWebDriver driver_)
        {
            this.driver_ = driver_;
        }
        public void calendar(string date_,string month_,string year_)
        {
            //string monthyearinput_= month_ + year_;
            //Actions action = new Actions(driver_);
            IJavaScriptExecutor scroll_ = (IJavaScriptExecutor)driver_;
            scroll_.ExecuteScript("window.scrollBy(0,500)");
            Thread.Sleep(2000);
            //IWebElement calenderbtn_ = driver_.FindElement(CalendarBtn);
            //action.MoveToElement(calenderbtn_);
            driver_.FindElement(CalendarBtn).Click();
            string assertcalendarpage_ = driver_.FindElement(AssertCalendarPage).Text;
            Assert.AreEqual("Calendars", assertcalendarpage_, "Error!!");
            
            driver_.FindElement(CalenderField).Click();
            Thread.Sleep(4000);
            CalenderYear = By.XPath("//div[@class='ui-datepicker-title']/child::span[@class='ui-datepicker-year']");
            CalenderMonth = By.XPath("//div[@class='ui-datepicker-title']/child::*[text()='" + month_ + "']");
            CalendarDate = By.XPath("//a[@class='ui-state-default' and text()='" + date_ + "']");
            //ui-datepicker-calendar
            string currentyear_;
            string currentmonth_;
            int currentyearint_;
            int givenyearint_;
            while (true)
            {
                Thread.Sleep(2000);
                currentmonth_ = driver_.FindElement(CalenderMonth).Text;
                currentyear_ = driver_.FindElement(CalenderYear).Text;
                currentyearint_ = int.Parse(currentyear_);
                givenyearint_ = int.Parse(year_);

                if (currentmonth_ == month_ && currentyear_ == year_)
                {
                    driver_.FindElement(CalendarDate).Click();
                    Console.WriteLine("Year =" + year_);
                    break;
                }
                else if(currentyearint_< givenyearint_)
                {

                    driver_.FindElement(CalendarNextBtn).Click();
                    continue;
                }
                else
                {
                    driver_.FindElement(CalendarPreBtn).Click();
                    continue;
                }

            }
            Thread.Sleep(8000);

        }
    }
}
