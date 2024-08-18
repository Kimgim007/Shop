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
            Assert.That(HeaderPage.SingInButton.ElementDispleed(), Is.True);
            HeaderPage.SingInButton.Click();
            AuthenticationPage.Login();
            var text = MyAccountPage.PageName.GetText();
            Assert.That(MyAccountPage.PageName.GetText() == "MY ACCOUNT", Is.True);
        }

        [Test]
        public void VerifySignInErrorDisplayed()
        {
            
        }
    }
}
