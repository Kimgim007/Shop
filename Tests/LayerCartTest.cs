using OpenQA.Selenium;
using Shop.Elements;
using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    internal class LayerCartTest : BaseTest
    {
        [Test]
        public void LayerCartVisible()
        {
            var element = HomePage.HomeFeaturedProductsPopular.FindChildElements()[0];
            var addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            BasePage.ActionClassReturn().MoveToElement(element).MoveToElement(addToCartButton).Click().Perform();

            LayerCartPage.LayerCart.WaitForElementVisible();
            Assert.That(LayerCartPage.LayerCart.ElementDispleed(), Is.True);
        }
        [Test]
        public void ContinueShoppingButton()
        {
            var element = HomePage.HomeFeaturedProductsPopular.FindChildElements()[0];
            var addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            BasePage.ActionClassReturn().MoveToElement(element).MoveToElement(addToCartButton).Click().Perform();

            LayerCartPage.LayerCart.WaitForElementVisible();

            Assert.That(LayerCartPage.ContinueShoppingButton.ElementDispleed(), Is.True);

            LayerCartPage.ContinueShoppingButton.Click();
            Thread.Sleep(500);
            Assert.That(LayerCartPage.LayerCart.ElementDispleed(), Is.False);
        }
        [Test]
        public void ProceedToChekoutButton()
        {
            var element = HomePage.HomeFeaturedProductsPopular.FindChildElements()[0];
            var addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            BasePage.ActionClassReturn().MoveToElement(element).MoveToElement(addToCartButton).Click().Perform();
            LayerCartPage.LayerCart.WaitForElementVisible();
            Assert.That(LayerCartPage.ProceedToChekoutButton.ElementDispleed(), Is.True);
            LayerCartPage.ProceedToChekoutButton.Click();

            Assert.That(CartPage.CartTitle.ElementDispleed(), Is.True);
        }
        [Test]
        public void CheckCartItemInfo()
        {
  
            Assert.That(HomePage.AddHomePageProductToCartAndVerifyDetails(0) != null, Is.True);
        }
    }
}
