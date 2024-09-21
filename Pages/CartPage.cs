using OpenQA.Selenium;
using Shop.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class CartPage:BasePage
    {
        public static Element CartTitle => new Element(By.XPath("//*[@id='cart_title']"));
        public static Element EmptyCatTitle => new Element(By.XPath("//*[@id='center_column']/p"));

        //У Класса Element есть метод FindElements если использовать AllProductLinks без метода то он найдёт первый элемент с таким же локатором а не все.
        public static Element AllProductLinks => new Element(By.XPath("//*[@class='cart_product']/a"));

        public static Element AllProductCart => new Element(By.XPath("//*[@id='cart_summary']/tbody"));

        public static Element RemoveFirstProductFromCart => new Element(By.XPath("//a[@title='Delete']"));
      
        public static Element ProceedToCheckoutInSummary => new Element(By.XPath("//p[@class='cart_navigation clearfix']/a"));
        public static Element ProceedToCheckoutInAddressAndShipping => new Element(By.XPath("//p[@class='cart_navigation clearfix']/button"));

        public static Element TermsOfService => new Element(By.XPath("//*[@id='cgv']"));

        public static Element AlertWarningPayment => new Element(By.XPath("//*[@id='center_column']/div/p"));

        //public static Element q => new Element(By.("//*[@id='center_column']/div/p"));
    }
}
