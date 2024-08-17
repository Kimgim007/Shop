using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    internal class YourAddressesTest : BaseTest
    {
        [Test]
        public void YourAddresses()
        {

            Assert.That(HomePage.SingInButton.ElementDispleed(), Is.True);
            HomePage.SingInButton.Click();
            AuthenticationPage.Login();

            MyAccountPage.AddMyFirstAddressButton.Click();

            BasePage.FillAndVerifyField(YourAddressesPage.FirstName, BasePage.firstName);

            BasePage.FillAndVerifyField(YourAddressesPage.LastName, BasePage.lastName);

            BasePage.FillAndVerifyField(YourAddressesPage.Company, BasePage.Company);

            BasePage.FillAndVerifyField(YourAddressesPage.Address, BasePage.Address);

            BasePage.FillAndVerifyField(YourAddressesPage.AddressLineTwo, BasePage.AddressLineTwo);

            BasePage.FillAndVerifyField(YourAddressesPage.ZipPostalCode, BasePage.ZipPostalCode);

            BasePage.FillAndVerifyField(YourAddressesPage.City, BasePage.City);

            Assert.That(BasePage.SelectDropdownOptionByText(YourAddressesPage.Country, BasePage.Country), Is.True);

            BasePage.FillAndVerifyField(YourAddressesPage.HomePhone, BasePage.HomePhone);

            BasePage.FillAndVerifyField(YourAddressesPage.MobilePhone, BasePage.MobilePhone);

            Assert.That(BasePage.SelectDropdownOptionByText(YourAddressesPage.State, BasePage.State), Is.True);

            BasePage.FillAndVerifyField(YourAddressesPage.AdditionalInformation, BasePage.AdditionalInformation);

            BasePage.FillAndVerifyField(YourAddressesPage.AliasAddress, BasePage.AliasAddress);

            YourAddressesPage.SaveButton.Click();

          
            Assert.That(MyAddresses.UpdateButton.ElementDispleed(), Is.True);


        }

    }
}
