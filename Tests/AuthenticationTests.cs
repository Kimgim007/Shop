using OpenQA.Selenium;
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
        public void CreateAnAccountErrorDisplayed()
        {
            Assert.That(HeaderPage.SingInButton.ElementDispleed(), Is.True);
            HeaderPage.SingInButton.Click();

            AuthenticationPage.CreateAccountEmailField.ClearField();
            AuthenticationPage.CreateAnAccountButton.Click();

            AuthenticationPage.EmptyCreateAccountEmailFieldWarning.WaitWebElementPresent();
            AuthenticationPage.EmptyCreateAccountEmailFieldWarningText.WaitWebElementPresent();

            Assert.That(AuthenticationPage.EmptyCreateAccountEmailFieldWarning.ElementDispleed() &&
                AuthenticationPage.EmptyCreateAccountEmailFieldWarningText.GetText().Contains("Invalid email address."), Is.True);
        }
        [Test]
        public void SignInErrorDisplayed()
        {

            Assert.That(HeaderPage.SingInButton.ElementDispleed(), Is.True);
            HeaderPage.SingInButton.Click();

            AuthenticationPage.SignInEmailField.ClearField();
            AuthenticationPage.SingInButton.Click();

            Assert.That(AuthenticationPage.EmptyEmailOrPasswordWarning.ElementDispleed() &&
                AuthenticationPage.EmptyEmailOrPasswordWarning.GetText().Contains("An email address required."), Is.True);

            AuthenticationPage.SignInEmailField.SentValue("camop332888@chaladas.com");
            AuthenticationPage.SingInButton.Click();

            Assert.That(AuthenticationPage.EmptyEmailOrPasswordWarning.ElementDispleed() &&
                AuthenticationPage.EmptyEmailOrPasswordWarning.GetText().Contains("Password is required."), Is.True);

            AuthenticationPage.SingPasswordField.SentValue("Secret_sauce0823");
            AuthenticationPage.SingInButton.Click();

            Assert.That(AuthenticationPage.EmptyEmailOrPasswordWarning.ElementDispleed() &&
              AuthenticationPage.EmptyEmailOrPasswordWarning.GetText().Contains("Authentication failed."), Is.True);
        }
    }
}
