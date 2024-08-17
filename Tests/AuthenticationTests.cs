using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    internal class AuthenticationTests : BaseTest
    {
        
        [Test]
        public void SingInAccount()
        {
            Assert.That(HomePage.SingInButton.ElementDispleed(), Is.True);
            HomePage.SingInButton.Click();
            AuthenticationPage.Login();
            var text = MyAccountPage.PageHeading.GetText();
            Assert.That(MyAccountPage.PageHeading.GetText() == "MY ACCOUNT", Is.True);
        }

        [Test]
        public void VerifySignInErrorDisplayed()
        {
            
        }
    }
}
