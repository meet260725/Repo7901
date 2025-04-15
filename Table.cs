using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automatenow.POM
{
    internal class Table
    {
        private readonly IWebDriver driver_;

        private By TableBtn = By.XPath("//a[@href='https://practice-automation.com/tables/']");
        private By SimpleTable = By.XPath("//div[@class='entry-content']/child::*/table");
        private By SimpleTableClm;
        private By SortableTableClm;

        public Table(IWebDriver driver_)
        {
            this.driver_ = driver_;
        }
        public void tablesection()
        { int i = 1;
            while(true) 
            {  
                
                SimpleTableClm = By.XPath("(//div[@class='entry-content']/child::*/table/tbody/tr/td/strong)["+i+"]");
                string column_= driver_.FindElement(SimpleTableClm).Text;
                    
            
            
            }
            while (true)
            {
                SortableTableClm = By.XPath("");
            }
        }
    }
}
