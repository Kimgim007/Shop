using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Shop.Elements;
using Shop.WebDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class BasePage
    {
        private static Actions actions = new Actions(Driver.GetDriver());

        public const string login = "camop332@chaladas.com";
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

        public static bool ClickClearEnterVerify(Element element, string text)
        {
            element.ClearField();
            element.SentValue($"{text}");
            var elementForDebug = element.GetValue();
            if (elementForDebug == null || elementForDebug.Length == 0 || elementForDebug != text)
            {
                return false;
            }
            return true;
        }

        public static bool WorkWithInput(Element element)
        {
            element.Click();
            var debugDot = element.IsInputFocused();
            return true;
        }

        public static void FillAndVerifyField(Element element,string textForComparison)
        {
            Assert.That(element.ElementDispleed(), Is.True);
            Assert.That(ClickClearEnterVerify(element,textForComparison), Is.True);
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
            return actions;
        }

        public static string GetBaseUrl(IWebElement webElement)
        {
            var baseProductLink = new Uri(webElement.GetAttribute("href")).GetLeftPart(UriPartial.Path);
            return baseProductLink;

        }

        public static string CurrentUrlSite()
        {
          
            return Driver.GetDriver().Url;

        }
    }
}
