using OpenQA.Selenium;
using Shop.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class OrderHistoryPage
    {
        public static Element PageHeading => new Element(By.XPath("//*[@id='center_column']/h1]"));
        public static Element AlertWarning => new Element(By.XPath("//*[@id='block-history']/p"));

        public static Element BackToYourAccontButton => new Element(By.XPath("//ul[@class='footer_links clearfix']/li/a"));
        public static Element HomeButton => new Element(By.XPath("//ul[@class='footer_links clearfix']/li[2]/a"));
     
    }
}
