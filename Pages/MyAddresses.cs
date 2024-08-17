using OpenQA.Selenium;
using Shop.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class MyAddresses
    {
        public static Element UpdateButton => new Element(By.XPath("//*[@id='center_column']/div[1]/div/div/ul/li[9]/a[1]/span"));
     
    }
}
