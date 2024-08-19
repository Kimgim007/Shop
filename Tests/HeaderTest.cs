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
    internal class HeaderTest : BaseTest
    {
        [Test]
        public void VerifySubMenuWOMEN()
        {
            HeaderPage.VerifySubMenuSubMenu(HeaderPage.WOMENButton, HeaderPage.SubMenuWOMENButton);

        }

        [Test]
        public void VerifySubMenuSubMenuDRESSES()
        {
            HeaderPage.VerifySubMenuSubMenu(HeaderPage.DRESSESButton, HeaderPage.SubMenuDRESSESButton);
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
            HeaderPage.LanguagesChange("//*[@id='languages-block-top']/ul/li[1]/a", "/ru/");
            HeaderPage.LanguagesChange("//*[@id='languages-block-top']/ul/li[2]/a", "/uk/");
            HeaderPage.LanguagesChange("//*[@id='languages-block-top']/ul/li[3]/a", "/en/");
        }

        [Test]
        public void CheckCurrencyChange()
        {
            HeaderPage.CurrencyChange(HeaderPage.CurrencyEUR, "Евро");
            HeaderPage.CurrencyChange(HeaderPage.CurrencyUSD, "Доллар");
            HeaderPage.CurrencyChange(HeaderPage.CurrencyUAH, "Гривна");

        }

    }
}
