using OpenQA.Selenium;
using Shop.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class HeaderPage : BasePage
    {

        public static Element SingInButton => new Element(By.XPath("//*[@class='login']"));
        public static Element FieldSearch => new Element(By.XPath("//*[@id='search_query_top']"));

        public static Element Header_logo => new Element(By.XPath("//*[@id='header_logo']/a"));
        public static Element Cart => new Element(By.XPath("//div[@class='shopping_cart']/a"));

        public static Element WOMENButton => new Element(By.XPath("//a[@title='Women']"));
        public static Element DRESSESButton => new Element(By.XPath("//*[@id='block_top_menu']/ul/li[2]/a"));
        public static Element TSHIRTSButton => new Element(By.XPath("//*[@id='block_top_menu']/ul/li[3]/a"));

        public static Element SubMenuWOMENButton => new Element(By.XPath("//li[1]/ul[@class='submenu-container clearfix first-in-line-xs']"));
        public static Element SubMenuDRESSESButton => new Element(By.XPath("//li[2]/ul[@class='submenu-container clearfix first-in-line-xs']"));

        public static Element TOPSSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li/a"));
        public static Element BlousesSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li/ul/li[2]/a"));
        public static Element SweatersSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li/ul/li[3]/a"));

        public static Element CasualDressesSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li[2]/ul/li/a"));
        public static Element EveningDressesSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li[2]/ul/li[2]/a"));
        public static Element SummerDressesSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li[2]/ul/li[3]/a"));

        public static Element JacketSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li[3]/a"));
        public static Element SuitsSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li[6]/a"));

        public static Element ShoesSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li[4]/a"));
        public static Element BagsSubMenuWOMEN => new Element(By.XPath("//ul[@class='submenu-container clearfix first-in-line-xs']/li[5]/a"));


        public static Element LanguagesBlock => new Element(By.XPath("//*[@id='languages-block-top']"));
        public static Element SetCurrency => new Element(By.XPath("//*[@id='setCurrency']"));

        public static Element CurrencyEUR => new Element(By.XPath("//*[@id='setCurrency']/ul/li[3]/a"));
        public static Element CurrencyUSD => new Element(By.XPath("//*[@id='setCurrency']/ul/li[2]/a"));
        public static Element CurrencyUAH => new Element(By.XPath("//*[@id='setCurrency']/ul/li/a"));

        public static Element CurrencySelected => new Element(By.XPath("//*[@id='setCurrency']/ul/li[@class='selected']/a"));


        public static void ScrollToElementAndMoveToElement(Element element)
        {
            element.ScrollToElement();
            element.MoveToElement();
        }

        public static bool CheckElementUrl(Element element, string urlCorrect)
        {
            var elementLink = element.GetUrl();
            Assert.That(elementLink.Contains(urlCorrect), Is.True);
            element.Click();
            var linkPage = CurrentUrlSite();
            return elementLink.Contains(linkPage);

        }

       
        public static void LanguagesChange(string languageLocator, string fragmentUrlFragment)
        {
            LanguagesBlock.ScrollToElement();
            LanguagesBlock.Click();
            var Languages = new Element(By.XPath($"{languageLocator}"));
            Languages.MoveToElement();
            Languages.Click();
            Assert.That(WaitForLanguageUrlUpdate($"{fragmentUrlFragment}").Contains($"{fragmentUrlFragment}"), Is.True);
        }

        public static void CurrencyChange(Element currency,string expectedCurrencyText)
        {
            SetCurrency.ScrollToElement();
            SetCurrency.Click();

            currency.WaitForElementVisible();
            currency.MoveToElement();
            currency.Click();

            SetCurrency.WaitForElementVisible();

            WaitForElementToUpdate(expectedCurrencyText, CurrencySelected);

            var actualCurrencyText = CurrencySelected.GetAttribute("title");

            Assert.That(actualCurrencyText.Contains(expectedCurrencyText), Is.True);
        }

        public static void VerifySubMenuSubMenu(Element SubMenuTriggerButton, Element SubMenuPanel)
        {
            SubMenuTriggerButton.ScrollToElement();
            SubMenuTriggerButton.MoveToElement();
            var sadasd = SubMenuPanel.GetAttribute("style");
            Assert.That(SubMenuPanel.ElementEnabled() && SubMenuPanel.GetAttribute("style") != "display: none;", Is.True);
        }
    }

}
