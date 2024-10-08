﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Shop.Elements;
using Shop.WebDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.Pages
{
    internal class BasePage
    {

        private static WebDriverWait wait => Driver.WaitDriver(Driver.GetDriver(), 30);

        public const string login = "camop332888@chaladas.com";
        public const string password = "Secret_sauce082351";

        public const string firstName = "Joni";
        public const string lastName = "Inglish";

        public const string Company = "Acme Corporation";
        public const string Address = "123 Main Street";
        public const string AddressLineTwo = "Apt 4B";
        public const string ZipPostalCode = "90210";
        public const string City = "Beverly Hills";
        public const string Country = "США";
        public const string HomePhone = "(310) 555-1234";
        public const string MobilePhone = "(310) 555-5678";
        public const string State = "Alabama";
        public const string AdditionalInformation = "N/A";
        public const string AliasAddress = "Home Address";

        public static bool CheckExpectedText(Element field, string text)
        {
            if (field.GetValue() != text)
            {
                return false;
            }
            return true;
        }

        public static void ClickClearEnter(Element element, string text)
        {
            element.ClearField();
            element.SentValue($"{text}");
        }

        public static bool ClickClearEnterVerify(Element element, string text)
        {
            ClickClearEnter(element, text);

            var elementForDebug = element.GetValue();
            if (elementForDebug == null || elementForDebug.Length == 0 || elementForDebug != text)
            {
                return false;
            }
            return true;
        }
        public static void FillAndVerifyField(Element element, string textForComparison)
        {
            Assert.That(element.ElementDisplayed(), Is.True);
            Assert.That(ClickClearEnterVerify(element, textForComparison), Is.True);
        }

        public static void WorkWithInput(Element element)
        {
            element.Click(); 
        }

        public static bool SelectDropdownOptionByText(Element dropdownElement, string optionText)
        {

            dropdownElement.Click();
            var options = dropdownElement.FindChildElements();
            foreach (var option in options)
            {
                if (option.Text.Trim() == optionText.Trim())
                {
                    option.Click();
                    return true;
                }
            }
            return false;
        }

        public static Actions ActionClassReturn()
        {
            Actions actions = new Actions(Driver.GetDriver());
            return actions;
        }

        public static string GetBaseUrl(IWebElement webElement)
        {
            var baseProductLink = new Uri(webElement.GetAttribute("href")).GetLeftPart(UriPartial.Path);
            return baseProductLink;
        }
        public static string WaitForLanguageUrlUpdate(string languages)
        {
            wait.Until(driver => driver.Url.Contains($"{languages}"));
            return Driver.GetDriver().Url;
        }
        public static bool WaitUntielElementDisappears(Element element)
        {
            var answer = wait.Until(driver =>
            {
                var actualCurrencyText = element.ElementDisplayed();
                return actualCurrencyText == false;
            });
            return answer;
        }
        public static string CurrentUrlSite()
        {
            return Driver.GetDriver().Url;

        }
        public static string ExtractColorAndSize(string text)
        {

            string[] parts = text.Split(new[] { "Color :", "Size :" }, StringSplitOptions.None);

            // Извлечение и очистка значений
            string color = parts[1].Split(',')[0].Trim();
            string size = parts[2].Trim();

            // Формирование строки вывода
            string result = $"{color}, {size}";
            return result;

        }

        public static bool WaitForElementElementExists(IWebElement webElement)
        {
            return Driver.WaitDriver(Driver.GetDriver(), 20).Until(q => webElement.Displayed);
        }
        public static bool WaitForElementToUpdate(string text, Element element)
        {
            return wait.Until(driver =>
            {
                var actualCurrencyText = element.GetAttribute("title");
                return actualCurrencyText.Contains(text);
            });
        }
        public static void AlertAccept()
        {
            Driver.GetDriver().SwitchTo().Alert().Accept();
        }

    }

}
