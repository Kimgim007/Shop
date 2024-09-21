using NUnit.Allure.Core;
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
    [AllureNUnit]
    internal class LayerCartTest : BaseTest
    {
        [Test]
        public void LayerCartVisible()
        {
            var element = HomePage.HomeFeaturedProductsPopular.FindChildElements()[0];
            var addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            BasePage.ActionClassReturn().MoveToElement(element).MoveToElement(addToCartButton).Click().Perform();

            LayerCartPage.LayerCart.WaitForElementElementExists();
            LayerCartPage.LayerCart.WaitForElementVisible();

            Assert.That(LayerCartPage.LayerCart.ElementDisplayed(), Is.True);
        }
        [Test]
        public void ContinueShoppingButton()
        {
            var element = HomePage.HomeFeaturedProductsPopular.FindChildElements()[0];
            var addToCartButton =  element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            BasePage.ActionClassReturn().MoveToElement(element).MoveToElement(addToCartButton).Click().Perform();

            LayerCartPage.LayerCart.WaitForElementElementExists();
            LayerCartPage.LayerCart.WaitForElementVisible();

            LayerCartPage.ContinueShoppingButton.Click();
            LayerCartPage.WaitUntielElementDisappears(LayerCartPage.LayerCart);
            Assert.That(LayerCartPage.LayerCart.ElementDisplayed(), Is.False);
        }
        [Test]
        public void ProceedToChekoutButton()
        {
            var element = HomePage.HomeFeaturedProductsPopular.FindChildElements()[0];
            var addToCartButton = element.FindElement(By.CssSelector("a.ajax_add_to_cart_button"));

            BasePage.ActionClassReturn().MoveToElement(element).MoveToElement(addToCartButton).Click().Perform();
            LayerCartPage.LayerCart.WaitForElementVisible();

            LayerCartPage.ProceedToChekoutButton.Click();

            Assert.That(CartPage.CartTitle.ElementDisplayed(), Is.True);
        }
        [Test]
        public void CheckCartItemInfo()
        {
  
            Assert.That(HomePage.AddHomePageProductToCartAndVerifyDetails(0) != null, Is.True);
        }
    }
}
