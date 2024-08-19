using OpenQA.Selenium;
using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    internal class HomeTest:BaseTest
    {
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
        public void CheckMoreButtonFunctionality()
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

                Thread.Sleep(2000);
                BasePage.ActionClassReturn().MoveToElement(element).Perform();

                moreToCartButton = element.FindElement(By.CssSelector("a.lnk_view.btn.btn"));
                ProductsLink = BasePage.GetBaseUrl(element.FindElement(By.XPath(".//a[@class='product_img_link']")));

                BasePage.ActionClassReturn().MoveToElement(moreToCartButton).Click().Perform();

                var currentUrl = BasePage.CurrentUrlSite();
                Assert.That(currentUrl == ProductsLink, Is.True);

                HeaderPage.Header_logo.Click();
            }
        }
       
    }
}
