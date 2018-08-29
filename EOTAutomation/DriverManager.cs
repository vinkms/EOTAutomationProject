using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace EOTAutomation
{
    public class DriverManager
    {
        IWebDriver driver;
        public IWebDriver ChromeDriver()
        {
            driver = new ChromeDriver();
            return driver;
        }

        public IWebDriver IEDriver()
        {
            driver = new InternetExplorerDriver();
            return driver;
        }

        public IWebDriver EdgeDriver()
        {
            driver = new EdgeDriver();
            return driver;
        }

        public IWebDriver FirefoxDriver()
        {
            driver = new FirefoxDriver();
            return driver;
        }
    }
}
