using OpenQA.Selenium;
using Shop.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class MyAccountPage
    {

        public static Element AlertSuccess => new Element(By.XPath("//*[@id='center_column']/p[1]"));

        public static Element PageHeading => new Element(By.XPath("//*[@class='page-heading']"));

        public static Element AddMyFirstAddressButton => new Element(By.XPath("//*[@title='Add my first address']"));

    }
}
