using NUnit.Allure.Core;
using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shop.Tests
{
    [AllureNUnit]
    internal class MyAccountTest:BaseTest
    {
        [Test]
        public void VerifyButtonOperationOrderHistoryAndDetails()
        {
            AuthenticationPage.Login();
            MyAccountPage.OrderHistoryAndDetailsButton.Click();

            Assert.That(OrderHistoryPage.AlertWarning.ElementDisplayed(), Is.True);
        }
        [Test]
        public void VerifyButtonMyCreditSlips()
        {
            AuthenticationPage.Login();
            MyAccountPage.MyCreditSlips.Click();

            Assert.That(OrderHistoryPage.AlertWarning.ElementDisplayed(), Is.True);
        }
        [Test]
        public void VerifyButtonMyAddresses()
        {
            AuthenticationPage.Login();
            MyAccountPage.MyAddresses.Click();

            Assert.That(MyAddressesPage.PageName.ElementDisplayed(), Is.True);
        }
        [Test]
        public void VerifyHomeButton()
        {
            AuthenticationPage.Login();
            MyAccountPage.HomeButton.Click();

            Assert.That(HomePage.SliderRow.ElementDisplayed(), Is.True);
        }
    }
}
