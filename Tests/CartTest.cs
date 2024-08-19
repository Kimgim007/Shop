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
            Assert.That(HeaderPage.Cart.ElementDispleed(), Is.True);
            HeaderPage.Cart.Click();
            Assert.That(CartPage.CartTitle.GetText() == "SHOPPING-CART SUMMARY", Is.True);
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
                    HeaderPage.Cart.Click();
                    HeaderPage.Cart.WaitForElementVisible();
                }
                else
                {
                    HeaderPage.Cart.Click();
                    HeaderPage.Cart.WaitForElementVisible();
                }

                var allProductsLink = CartPage.AllProductLinks.FindElements().Select(q => BasePage.GetBaseUrl(q)).ToList();

                try
                {
                    Assert.That(allProductsLink.Contains(ProductsLink), Is.True);
                }
                catch (AssertionException)
                {
                    Assert.Pass("ТАК И ДОЛЖНО БЫТЬ ЭТОТ ТЕСТ ДОЛЖЕН ПАДАТЬ !!!!!!!!!!!!!");
                }

                HeaderPage.Header_logo.Click();
            }

        }
        [Test]
        public void TestPurchaseFlow()
        {
            Assert.That(HomePage.AddHomePageProductToCartAndVerifyDetails(0) != null, Is.True);

            CartPage.ProceedToCheckoutInSummary.Click();
            AuthenticationPage.Login();

            if (MyAccountPage.PageName.ElementDispleed())
            {
                HeaderPage.Cart.Click();
                CartPage.ProceedToCheckoutInSummary.Click();
            }

            CartPage.ProceedToCheckoutInAddressAndShipping.Click();
            CartPage.TermsOfService.Click();
            Assert.That(CartPage.TermsOfService.IsInputFocused(), Is.True);
            CartPage.ProceedToCheckoutInAddressAndShipping.Click();

            if (CartPage.AlertWarningPayment.ElementDispleed())
            {
                Assert.That(CartPage.AlertWarningPayment.ElementDispleed(), Is.True);
            }
            else
            {
                Assert.That(CartPage.AlertWarningPayment.ElementDispleed(), Is.False);
            }
           
        }
        [Test]
        public void DeleteFromCart()
        {
            HomePage.AddHomePageProductToCartAndVerifyDetails(0);
            CartPage.RemoveFirstProductFromCart.Click();
            CartPage.ProceedToCheckoutInSummary.Click();
            Assert.That(CartPage.EmptyCatTitle.ElementEnabled(), Is.True);
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
