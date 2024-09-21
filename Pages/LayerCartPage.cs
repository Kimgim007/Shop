using OpenQA.Selenium;
using Shop.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class LayerCartPage:BasePage
    {
        public static Element LayerCart => new Element(By.XPath(" //*[@id='layer_cart']"));
        public static Element Cross => new Element(By.XPath("//*[@class='cross']"));
        public static Element ItemAddedToCartMessage => new Element(By.XPath("//*[@class='icon-ok']"));
        public static Element ContinueShoppingButton => new Element(By.XPath("//div[@class='button-container']/span"));
        public static Element ProceedToChekoutButton => new Element(By.XPath("//a[@class='btn btn-default button button-medium']"));
        public static Element ProductPrice => new Element(By.XPath("//span[@id='layer_cart_product_price']"));
        public static Element ProductQuantity => new Element(By.XPath("//span[@id='layer_cart_product_quantity']"));
        public static Element ProductAttributes => new Element(By.XPath("//span[@id='layer_cart_product_attributes']"));
    }
}
