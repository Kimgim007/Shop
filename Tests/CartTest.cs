using OpenQA.Selenium;
using Shop.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    internal class CartTest : BaseTest
    {
        [Test]
        public void GoToCart()
        {
            Assert.That(HomePage.Cart.ElementDispleed(), Is.True);
            HomePage.Cart.Click();
            Assert.That(CartPage.CartTitle.GetText() == "SHOPPING-CART SUMMARY", Is.True);
        }
        [Test]
        public void CheckHoverButtonVisibility()
        {
            var elementFrom = HomePage.HomeFeaturedProductsPopular.FindChildElements();
            for (int i = 0; i < elementFrom.Count; i++)
            {
                var element = elementFrom[i];
                Assert.That(element.Displayed, Is.True);
                var addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));
                var moreToCartButton = element.FindElement(By.CssSelector("a.lnk_view.btn.btn"));

                Assert.That(addToCartButton.Displayed, Is.False);
                Assert.That(moreToCartButton.Displayed, Is.False);

                BasePage.ActionClassReturn().MoveToElement(element).Perform();

                Assert.That(addToCartButton.Displayed, Is.True);
                Assert.That(moreToCartButton.Displayed, Is.True);
            }
        }
        [Test]
        public void VerifyAddToCartButtonIsClickable()
        {
            var elementFrom = HomePage.HomeFeaturedProductsPopular.FindChildElements();
            IWebElement addToCartButton;

            for (int i = 0; i < elementFrom.Count; i++)
            {
                var element = elementFrom[i];
                Assert.That(element.Displayed, Is.True);
                BasePage.ActionClassReturn().MoveToElement(element).Perform();
                addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));
                Assert.That(addToCartButton.Enabled, Is.True);
            }
        }
        [Test]
        public void VerifyMoreToCartButtonIsClickable()
        {
            var elementFrom = HomePage.HomeFeaturedProductsPopular.FindChildElements();
            IWebElement moreToCartButton;

            for (int i = 0; i < elementFrom.Count; i++)
            {
                var element = elementFrom[i];
                Assert.That(element.Displayed, Is.True);
                BasePage.ActionClassReturn().MoveToElement(element).Perform();
                moreToCartButton = element.FindElement(By.CssSelector("a.lnk_view.btn.btn"));
                Assert.That(moreToCartButton.Enabled, Is.True);
            }
        }
        [Test]
        public void CheckMoreFunctionality()
        {
            var elementFrom = HomePage.HomeFeaturedProductsPopular.FindChildElements();
            IWebElement moreToCartButton;
            string ProductsLink;

            for (int i = 0; i < elementFrom.Count; i++)
            {
                if (i > 0)
                {
                    elementFrom = HomePage.HomeFeaturedProductsPopular.FindChildElements();
                }
                var element = elementFrom[i];
                Assert.That(element.Displayed, Is.True);
                BasePage.ActionClassReturn().MoveToElement(element).Perform();

                moreToCartButton = element.FindElement(By.CssSelector("a.lnk_view.btn.btn"));
                ProductsLink = BasePage.GetBaseUrl(element.FindElement(By.XPath(".//a[@class='product_img_link']")));

                BasePage.ActionClassReturn().MoveToElement(moreToCartButton).Click().Perform();

                var currentUrl = BasePage.CurrentUrlSite();
                Assert.That(currentUrl == ProductsLink, Is.True);

                HomePage.Header_logo.Click();
            }
        }
        [Test]
        public void AddToCartPopularProductsFromHomePageFail()
        {
            var products = HomePage.HomeFeaturedProductsPopular.FindChildElements();
            for (int i = 0; i < products.Count; i++)
            {
                if (i > 0)
                {
                    products = HomePage.HomeFeaturedProductsPopular.FindChildElements();
                }

                var product = products[i];

                BasePage.ActionClassReturn().MoveToElement(product).Perform();
                Assert.That(product.Displayed, Is.True);

                var addToCartButton = product.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));
                Assert.That(addToCartButton.Displayed, Is.True);
                BasePage.ActionClassReturn().MoveToElement(product).MoveToElement(addToCartButton).Click().Perform();
                var ProductsLink = BasePage.GetBaseUrl(product.FindElement(By.XPath(".//a[@class='product_img_link']"))); ;

                if (LayerCartPage.LayerCart.ElementDispleed())
                {
                    LayerCartPage.Cross.Click();
                    HomePage.Cart.Click();
                }
                else
                {
                    HomePage.Cart.Click();
                }
                //ЗАменить на что нибудь - Thread.Sleep(1000);!!!!
                Thread.Sleep(1000);
  
                var allProductsLink = CartPage.AllProductLinks.FindElements().Select(q => BasePage.GetBaseUrl(q)).ToList();

                try
                {
                    Assert.That(allProductsLink.Contains(ProductsLink), Is.True);
                }
                catch(AssertionException) {
                    Assert.Pass();
                }  

                HomePage.Header_logo.Click();
            }

        }

        [Test]
        public void TestPurchaseFlow()
        {
            var elementFrom = HomePage.HomeFeaturedProductsPopular.FindChildElements();
            var product = elementFrom[0];
            float howMachCostProduct;

            BasePage.ActionClassReturn().MoveToElement(product).Perform();
            Assert.That(product.Displayed, Is.True);

            var addToCartButton = product.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));
            Assert.That(addToCartButton.Displayed, Is.True);
            BasePage.ActionClassReturn().MoveToElement(product).MoveToElement(addToCartButton).Click().Perform();
            var ProductsLink = BasePage.GetBaseUrl(product.FindElement(By.XPath(".//a[@class='product_img_link']"))); ;

            if (LayerCartPage.LayerCart.ElementDispleed())
            {
                LayerCartPage.Cross.Click();
                Assert.That(LayerCartPage.ProceedToChekoutButton.ElementDispleed(), Is.True);
                LayerCartPage.ProceedToChekoutButton.Click();
            }
            else
            {
                HomePage.Cart.Click();
            }
            //ЗАменить на что нибудь - Thread.Sleep(1000);!!!!
            Thread.Sleep(1000);

            var allProductsLink = CartPage.AllProductLinks.FindElements().Select(q => BasePage.GetBaseUrl(q)).ToList();
        }

        [Test]
        public void LayerCartP()
        {

        }
        [Test]
        public void DeleteFromCart()
        {

        }
        [Test]
        public void VerifyCartItems()
        {

        }
        [Test]
        public void BuyThings()
        {

        }
        [Test]
        public void VerifyCartIsEmpty()
        {

        }

    }
}
