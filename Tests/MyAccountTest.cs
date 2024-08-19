using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shop.Tests
{
    internal class MyAccountTest:BaseTest
    {
        [Test]
        public void VerifyButtonOperationOrderHistoryAndDetails()
        {
            AuthenticationPage.Login();
            Assert.That(MyAccountPage.OrderHistoryAndDetailsButton.ElementDispleed(), Is.True);
            MyAccountPage.OrderHistoryAndDetailsButton.Click();

            Assert.That(OrderHistoryPage.AlertWarning.ElementDispleed(), Is.True);
        }
        [Test]
        public void VerifyButtonMyCreditSlips()
        {
            AuthenticationPage.Login();
            Assert.That(MyAccountPage.MyCreditSlips.ElementDispleed(), Is.True);
            MyAccountPage.MyCreditSlips.Click();

            Assert.That(OrderHistoryPage.AlertWarning.ElementDispleed(), Is.True);
        }
        [Test]
        public void VerifyButtonMyAddresses()
        {
            AuthenticationPage.Login();
            Assert.That(MyAccountPage.MyAddresses.ElementDispleed(), Is.True);
            MyAccountPage.MyAddresses.Click();
            Assert.That(MyAddressesPage.PageName.ElementDispleed(), Is.True);
        }
        [Test]
        public void VerifyHomeButton()
        {
            AuthenticationPage.Login();
            Assert.That(MyAccountPage.HomeButton.ElementDispleed(), Is.True);
            MyAccountPage.HomeButton.Click();
            Assert.That(HomePage.SliderRow.ElementDispleed(), Is.True);
        }
    }
}
