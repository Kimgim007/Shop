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
        
        public static Element PopularButton => new Element(By.XPath("//*[@id='home-page-tabs']/li[1]/a"));
        public static Element BestSellersButton => new Element(By.XPath("//*[@id='home-page-tabs']/li[2]/a"));
        public static Element HomeFeaturedProductsPopular => new Element(By.XPath("//*[@id='homefeatured']"));

        public static Element SliderRow => new Element(By.XPath("//div[@id='slider_row']"));

        public static IWebElement AddHomePageProductToCartAndVerifyDetails(int index)
        {
            
            var elementFrom = HomeFeaturedProductsPopular.FindChildElements();
            var product = elementFrom[index];

            string priceProduct;
            string productQuantity;
            string productAttributes;

            ActionClassReturn().MoveToElement(product).Perform();

            var addToCartButton = product.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            ActionClassReturn().MoveToElement(product).MoveToElement(addToCartButton).Click().Perform();

            LayerCartPage.LayerCart.WaitForElementVisible();

            var ProductsLink = GetBaseUrl(product.FindElement(By.XPath(".//a[@class='product_img_link']")));

            priceProduct = LayerCartPage.ProductPrice.GetText();
            productQuantity = LayerCartPage.ProductQuantity.GetText();
            productAttributes = LayerCartPage.ProductAttributes.GetText();

            LayerCartPage.ProceedToChekoutButton.Click();

            var allProductsLink = CartPage.AllProductLinks.FindElements().Select(q => BasePage.GetBaseUrl(q)).ToList();

            var allproductsCart = CartPage.AllProductCart.FindElements();

            var filteredProducts = allproductsCart
           .FirstOrDefault(element =>
           {
               var href = element.FindElement(By.XPath("//td[@class='cart_product']/a"));

               var priceProductText = element.FindElement(By.XPath("//td[@class='cart_unit']/span/span")).Text;
               var productQuantityText = element.FindElement(By.XPath(" //*[@class='cart_quantity_input form-control grey']")).GetAttribute("value");
               var productColorSizeText = element.FindElement(By.XPath("//td[@class='cart_description']/small/a")).Text;

               return GetBaseUrl(href) == ProductsLink &&
               priceProductText == priceProduct &&
               productQuantityText == productQuantity &&
               ExtractColorAndSize(productColorSizeText) == productAttributes;
           });

            return filteredProducts;
        }
    }
}
