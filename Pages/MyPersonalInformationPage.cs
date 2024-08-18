using OpenQA.Selenium;
using Shop.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class MyPersonalInformationPage : BasePage
    {
        public static Element PageName => new Element(By.XPath("//*[@class='page-subheading']"));
        
        public static Element RadioGender_1 => new Element(By.XPath("//*[@id='id_gender1']"));
        public static Element RadioGender_2 => new Element(By.XPath("//*[@id='id_gender2']"));
        public static Element FirstNameFieldForRegistration => new Element(By.XPath("//*[@id='customer_firstname']"));
        public static Element LastNameFieldRegistration => new Element(By.XPath("//*[@id='customer_lastname']"));

        public static Element FirstNameFieldForUpdate => new Element(By.XPath("//*[@id='firstname']"));
        public static Element LastNameFieldForUpdate => new Element(By.XPath("//*[@id='lastname']"));

        public static Element DetailsEmailField => new Element(By.XPath("//*[@id='email']"));
        public static Element PasswordFieldForCreateAccount => new Element(By.XPath("//*[@id='passwd']"));

        public static Element OldPasswdFieldForUpdate => new Element(By.XPath("//*[@id='old_passwd']"));
        public static Element NewPassworField => new Element(By.XPath("//*[@id='passwd']"));

        public static Element DateOfBirthDays => new Element(By.XPath("//*[@id='days']"));
        public static Element DateOfBirthMonths => new Element(By.XPath("//*[@id='months']"));
       
        public static Element FrameYears => new Element(By.XPath("//*[@id='cuselFrame-years']"));
        public static Element DateOfBirthYears => new Element(By.XPath("//*[@id='cusel-scroll-years']"));
        public static Element jScrollPaneDrag => new Element(By.XPath("//*[@class='jScrollPaneDrag']"));

        public static Element EndCreateAnAccountButton => new Element(By.XPath("//*[@id='submitAccount']"));
        public static Element UpdatetAndSaveButtonYourPersonalInformation => new Element(By.XPath("//*[@id='center_column']/div/div/button"));


        public static bool WorkWithDateOfBirth()
        {
            if (!SelectDropdownOptionByText(DateOfBirthDays, "29"))
            {
                return false;
            }

            if (!SelectDropdownOptionByText(DateOfBirthMonths, "January"))
            {
                return false;
            }

            var text = "";
            FrameYears.Click();
            var yearSelected = DateOfBirthYears.FindChildElements();
            jScrollPaneDrag.ScrollPane(30);
            yearSelected[25].Click();
            text = FrameYears.GetText();
            if (text != "2000  ")
            {
                return false;
            }
            return true;
                   
        }
    }
}
