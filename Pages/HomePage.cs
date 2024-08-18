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
            var elementFrom = HomePage.HomeFeaturedProductsPopular.FindChildElements();
            var product = elementFrom[index];

            string priceProduct;
            string productQuantity;
            string productAttributes;

            BasePage.ActionClassReturn().MoveToElement(product).Perform();
            Assert.That(product.Displayed, Is.True);

            var addToCartButton = product.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));
            Assert.That(addToCartButton.Displayed, Is.True);

            BasePage.ActionClassReturn().MoveToElement(product).MoveToElement(addToCartButton).Click().Perform();

            LayerCartPage.LayerCart.WaitForElementVisible();

            var ProductsLink = BasePage.GetBaseUrl(product.FindElement(By.XPath(".//a[@class='product_img_link']")));

            Assert.That(LayerCartPage.ProceedToChekoutButton.ElementDispleed(), Is.True);

            priceProduct = LayerCartPage.ProductPrice.GetText();
            productQuantity = LayerCartPage.ProductQuantity.GetText();
            productAttributes = LayerCartPage.ProductAttributes.GetText();


            LayerCartPage.ProceedToChekoutButton.Click();

            var allProductsLink = CartPage.AllProductLinks.FindElements().Select(q => BasePage.GetBaseUrl(q)).ToList();
            Assert.That(allProductsLink.Contains(ProductsLink), Is.True);

            var allproductsCart = CartPage.AllProductCart.FindElements();

            var filteredProducts = allproductsCart
           .FirstOrDefault(element =>
           {
               var href = element.FindElement(By.XPath("//td[@class='cart_product']/a"));

               var priceProductText = element.FindElement(By.XPath("//td[@class='cart_unit']/span/span")).Text;
               var productQuantityText = element.FindElement(By.XPath(" //*[@class='cart_quantity_input form-control grey']")).GetAttribute("value");
               var productColorSizeText = element.FindElement(By.XPath("//td[@class='cart_description']/small/a")).Text;

               return BasePage.GetBaseUrl(href) == ProductsLink &&
               priceProductText == priceProduct &&
               productQuantityText == productQuantity &&
               BasePage.ExtractColorAndSize(productColorSizeText) == productAttributes;
           });

            return filteredProducts;
        }
    }
}
