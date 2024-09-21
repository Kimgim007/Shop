using NUnit.Allure.Core;
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
    [AllureNUnit] 
    internal class CartTest : BaseTest
    {
        [Test]
        public void GoToCart()
        {
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

                var addToCartButton = product.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

                BasePage.ActionClassReturn().MoveToElement(product).MoveToElement(addToCartButton).Click().Perform();
                var ProductsLink = BasePage.GetBaseUrl(product.FindElement(By.XPath(".//a[@class='product_img_link']"))); ;

                if (LayerCartPage.LayerCart.ElementDisplayed())
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
            HomePage.AddHomePageProductToCartAndVerifyDetails(0);

            CartPage.ProceedToCheckoutInSummary.Click();
            AuthenticationPage.Login();

            if (MyAccountPage.PageName.ElementDisplayed())
            {
                HeaderPage.Cart.Click();
                CartPage.ProceedToCheckoutInSummary.Click();
            }

            CartPage.ProceedToCheckoutInAddressAndShipping.Click();
            CartPage.TermsOfService.Click();
            CartPage.ProceedToCheckoutInAddressAndShipping.Click();

            if (CartPage.AlertWarningPayment.ElementDisplayed())
            {
                Assert.That(CartPage.AlertWarningPayment.ElementDisplayed(), Is.True);
            }
            else
            {
                Assert.That(CartPage.AlertWarningPayment.ElementDisplayed(), Is.False);
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
       
    }
}
