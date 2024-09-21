using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.WebDrive
{
    internal class Driver
    {
        private static IWebDriver? driver;

        private static WebDriverWait? wait;

        public static IWebDriver GetDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--lang=en-US");

            if (driver == null)
            {

                driver = new ChromeDriver(options);
            }
            return driver;
        }
        public static WebDriverWait WaitDriver(IWebDriver driver, double time)
        {

            if (wait == null)
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            }
            return wait;
        }

        public static void TeareDown()
        {
            driver.Quit();
            driver = null;
            wait = null;
        }
    }
}
