using NUnit.Allure.Core;
using OpenQA.Selenium;
using Shop.Pages;
using Shop.WebDrive;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    [AllureNUnit]
    internal class YourAddressesTest : BaseTest
    {
        [Test]
        public void AddMyFirstAddress()
        {

            AuthenticationPage.Login();
            if (MyAccountPage.AddMyFirstAddressButton.ElementDisplayed())
            {
                MyAccountPage.AddMyFirstAddressButton.Click();
            }
            else
            {
                MyAccountPage.MyAddresses.Click();
                MyAddressesPage.DeleteButton.Click();
                BasePage.AlertAccept();
                MyAddressesPage.AddANewAddress.Click();
            }

            YourAddressesPage.FillAddressDetails(BasePage.firstName, BasePage.lastName, BasePage.Company,
                BasePage.Address, BasePage.AddressLineTwo, BasePage.ZipPostalCode,
                BasePage.City, BasePage.Country, BasePage.HomePhone, BasePage.MobilePhone,
                BasePage.State, BasePage.AdditionalInformation, BasePage.AliasAddress);

            YourAddressesPage.SaveButton.Click();

            Assert.That(MyAddressesPage.InformationBox.ElementDisplayed(), Is.True);

        }
        [Test]
        public void UpdateAddresses()
        {

            AuthenticationPage.Login();

            MyAccountPage.MyAddresses.Click();

            MyAddressesPage.UpdateButton.Click();

            string firstName = "Jane";
            string lastName = "Doe";

            string company = "Tech Solutions Inc.";
            string address = "456 Elm Street";
            string addressLineTwo = "Suite 7C";
            string zipPostalCode = "12345";
            string city = "Springfield";
            string country = "Украина";
            string homePhone = "(555) 123-4567";
            string mobilePhone = "(555) 987-6543";
            string state = "Одесская область";
            string additionalInformation = "Office located on the 7th floor";
            string aliasAddress = "Work Address";

            YourAddressesPage.FillAddressDetails(firstName, lastName, company,
            address, addressLineTwo, zipPostalCode,
            city, country, homePhone, mobilePhone,
            state, additionalInformation, aliasAddress);

            YourAddressesPage.SaveButton.Click();

            var firstNameElementText = MyAddressesPage.InformationBox.FindElement(By.CssSelector(".address_name:nth-of-type(1)")).Text;
            var lastNameElementText = MyAddressesPage.InformationBox.FindElement(By.CssSelector(".address_name:nth-of-type(2)")).Text;
            var companyElementText = MyAddressesPage.InformationBox.FindElement(By.CssSelector(".address_company")).Text;
            var addressLine1ElementText = MyAddressesPage.InformationBox.FindElement(By.CssSelector(".address_address1")).Text;
            var addressLine2ElementText = MyAddressesPage.InformationBox.FindElement(By.CssSelector(".address_address2")).Text;
            var cityElementText = MyAddressesPage.InformationBox.FindElement(By.CssSelector(".address_city")).Text;
            var zipCodeElementText = MyAddressesPage.InformationBox.FindElement(By.XPath("//ul[@class='last_item item box']/li[7]/span")).Text;
            var countryElementText = MyAddressesPage.InformationBox.FindElement(By.XPath("//ul[@class='last_item item box']/li[8]/span")).Text;
            var homePhoneElementText = MyAddressesPage.InformationBox.FindElement(By.CssSelector(".address_phone")).Text;
            var mobilePhoneElementText = MyAddressesPage.InformationBox.FindElement(By.CssSelector(".address_phone_mobile")).Text;

            Assert.That(
                firstNameElementText == firstName &&
                lastNameElementText == lastName &&
                companyElementText == company &&
                addressLine1ElementText == address &&
                addressLine2ElementText == addressLineTwo &&
                cityElementText == city &&
                zipCodeElementText == zipPostalCode &&
                countryElementText == country &&
                homePhoneElementText == homePhone &&
                mobilePhoneElementText == mobilePhone,
                         Is.True);

        }
        [Test]
        public void ErrorMessageDisplayed()
        {
            HeaderPage.SingInButton.Click();
            AuthenticationPage.Login();

            if (MyAccountPage.AddMyFirstAddressButton.ElementDisplayed())
            {
                MyAccountPage.AddMyFirstAddressButton.Click();
            }
            else
            {
                Assert.That(MyAccountPage.MyAddresses.ElementDisplayed(), Is.True);
                MyAccountPage.MyAddresses.Click();

                Assert.That(MyAddressesPage.UpdateButton.ElementDisplayed(), Is.True);
                MyAddressesPage.UpdateButton.Click();
            }

            YourAddressesPage.SaveButton.Click();

            Assert.That(YourAddressesPage.ErrorMessage.ElementDisplayed(), Is.True);
        }
    }
}
