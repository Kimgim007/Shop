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

        //У Класса Element есть метод FindElements если использовать AllProdutNameInCart без метода то он найдёт первый элемент с таким же локатором а не все.
        public static Element AllProdutNameInCart => new Element(By.XPath("//p[@class='product-name']"));

        //У Класса Element есть метод FindElements если использовать AllProductLinks без метода то он найдёт первый элемент с таким же локатором а не все.
        public static Element AllProductLinks => new Element(By.XPath("//*[@class='cart_product']/a"));  
        //public static Element q => new Element(By.XPath(""));
        //public static Element q => new Element(By.XPath(""));
        //public static Element q => new Element(By.XPath(""));
        //public static Element q => new Element(By.XPath(""));
        //public static Element q => new Element(By.XPath(""));
        //public static Element q => new Element(By.XPath(""));
        //public static Element q => new Element(By.XPath(""));
    }
}
