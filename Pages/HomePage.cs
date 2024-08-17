using OpenQA.Selenium;
using Shop.Elements;
using Shop.WebDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class HomePage:BasePage
    {
     
        public static Element Header_logo => new Element(By.XPath("//*[@id='header_logo']/a"));
        public static Element SingInButton => new Element(By.XPath("//*[@class='login']"));
        public static Element FieldSearch => new Element(By.XPath("//*[@id='search_query_top']"));

        public static Element PopularButton => new Element(By.XPath("//*[@id='home-page-tabs']/li[1]/a"));

        public static Element BestSellersButton => new Element(By.XPath("//*[@id='home-page-tabs']/li[2]/a"));

        public static Element HomeFeaturedProductsPopular => new Element(By.XPath("//*[@id='homefeatured']"));
  
     
        
        public static Element Cart => new Element(By.XPath("//div[@class='shopping_cart']/a"));

       
    }
}
