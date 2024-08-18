using OpenQA.Selenium;
using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    internal class HeaderTest : BaseTest
    {
        [Test]
        public void VerifySubMenuWOMEN()
        {
            HeaderPage.WOMENButton.ScrollToElement();
            HeaderPage.WOMENButton.MoveToElement();
            var sadasd = HeaderPage.SubMenuWOMENButton.GetAttribute("style");
            Assert.That(HeaderPage.SubMenuWOMENButton.ElementEnabled() && HeaderPage.SubMenuWOMENButton.GetAttribute("style") != "display: none;", Is.True);

        }

        [Test]
        public void VerifySubMenuSubMenuDRESSES()
        {
            HeaderPage.DRESSESButton.ScrollToElement();
            HeaderPage.DRESSESButton.MoveToElement();
            var sadasd = HeaderPage.SubMenuDRESSESButton.GetAttribute("style");
            Assert.That(HeaderPage.SubMenuDRESSESButton.ElementEnabled() && HeaderPage.SubMenuDRESSESButton.GetAttribute("style") != "display: none;", Is.True);
        }

        [Test]
        public void VerifyWOMENTabNavigationAllButton()
        {
            string correctUrlWOMENButton = "http://prestashop.qatestlab.com.ua/en/3-women";
            string correctUrlDRESSESButton = "http://prestashop.qatestlab.com.ua/en/8-dresses";
            string correctUrlTSHIRTSButton = "http://prestashop.qatestlab.com.ua/en/5-tshirts";
            string correctUrlTOPSSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/4-tops";
            string correctUrlBlousesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/7-blouses";
            string correctUrlSweatersSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/12-sweaters";
            string correctUrlCasualDressesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/9-casual-dresses";
            string correctUrlEveningDressesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/10-evening-dresses";
            string correctUrlSummerDressesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/11-summer-dresses";
            string correctUrlJacketSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/14-jackets";
            string correctUrlSuitsSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/17-suits";
            string correctUrlShoesSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/15-shoes";
            string correctUrlBagsSubMenuWOMEN = "http://prestashop.qatestlab.com.ua/en/16-bags";


            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.WOMENButton, correctUrlWOMENButton));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.DRESSESButton, correctUrlDRESSESButton));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.TSHIRTSButton, correctUrlTSHIRTSButton));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.TOPSSubMenuWOMEN, correctUrlTOPSSubMenuWOMEN));
        
            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.BlousesSubMenuWOMEN, correctUrlBlousesSubMenuWOMEN));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.SweatersSubMenuWOMEN, correctUrlSweatersSubMenuWOMEN));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.CasualDressesSubMenuWOMEN, correctUrlCasualDressesSubMenuWOMEN));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.EveningDressesSubMenuWOMEN, correctUrlEveningDressesSubMenuWOMEN));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.SummerDressesSubMenuWOMEN, correctUrlSummerDressesSubMenuWOMEN));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.JacketSubMenuWOMEN, correctUrlJacketSubMenuWOMEN));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.SuitsSubMenuWOMEN, correctUrlSuitsSubMenuWOMEN));   

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.ShoesSubMenuWOMEN, correctUrlShoesSubMenuWOMEN));

            HeaderPage.ScrollToElementAndMoveToElement(HeaderPage.WOMENButton);
            Assert.That(HeaderPage.CheckElementUrl(HeaderPage.BagsSubMenuWOMEN, correctUrlBagsSubMenuWOMEN));
        }

        [Test] 
        public void CheckLanguageChange()
        {
 

            HeaderPage.LanguagesBlock.ScrollToElement();
            HeaderPage.LanguagesBlock.Click();
            var russianLanguages = HeaderPage.LanguagesBlock.FindElement(By.XPath("//*[@id='languages-block-top']/ul/li[1]/a"));
            russianLanguages.Click();
            Assert.That(BasePage.CurrentUrlSite().Contains("/ru/"), Is.True);

            HeaderPage.LanguagesBlock.ScrollToElement();
            HeaderPage.LanguagesBlock.Click();
            var ukrainianLanguage = HeaderPage.LanguagesBlock.FindElement(By.XPath("//*[@id='languages-block-top']/ul/li[2]/a"));
            ukrainianLanguage.Click();
            Assert.That(BasePage.CurrentUrlSite().Contains("/uk/"), Is.True);

            HeaderPage.LanguagesBlock.ScrollToElement();
            HeaderPage.LanguagesBlock.Click();
            var englishLanguage = HeaderPage.LanguagesBlock.FindElement(By.XPath("//*[@id='languages-block-top']/ul/li[3]/a"));
            englishLanguage.Click();
            Assert.That(BasePage.CurrentUrlSite().Contains("/en/"), Is.True);
        }
    }
}
