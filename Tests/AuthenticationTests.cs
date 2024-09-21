using NUnit.Allure.Core;
using OpenQA.Selenium;
using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    [AllureNUnit]
    internal class AuthenticationTests : BaseTest
    {

        [Test]
        public void SingInAccount()
        {
            HeaderPage.SingInButton.Click();
            AuthenticationPage.Login();
            Assert.That(MyAccountPage.PageName.GetText() == "MY ACCOUNT", Is.True);
        }
        [Test]
        public void CreateAnAccountErrorDisplayed()
        {
            HeaderPage.SingInButton.Click();

            AuthenticationPage.CreateAccountEmailField.ClearField();
            AuthenticationPage.CreateAnAccountButton.Click();

            AuthenticationPage.EmptyCreateAccountEmailFieldWarning.WaitWebElementPresent();
            AuthenticationPage.EmptyCreateAccountEmailFieldWarningText.WaitWebElementPresent();

            Assert.That(AuthenticationPage.EmptyCreateAccountEmailFieldWarning.ElementDisplayed() &&
                AuthenticationPage.EmptyCreateAccountEmailFieldWarningText.GetText().Contains("Invalid email address."), Is.True);
        }
        [Test]
        public void EmptyEmailWarning()
        {
            HeaderPage.SingInButton.Click();

            AuthenticationPage.SignInEmailField.ClearField();
            AuthenticationPage.SingInButton.Click();

            Assert.That(AuthenticationPage.EmptyEmailOrPasswordWarning.ElementDisplayed() &&
                AuthenticationPage.EmptyEmailOrPasswordWarning.GetText().Contains("An email address required."), Is.True);

        }
        [Test]
        public void PasswordWarning()
        {
            HeaderPage.SingInButton.Click();

            AuthenticationPage.SignInEmailField.SentValue("camop332888@chaladas.com");
            AuthenticationPage.SingInButton.Click();

            Assert.That(AuthenticationPage.EmptyEmailOrPasswordWarning.ElementDisplayed() &&
                AuthenticationPage.EmptyEmailOrPasswordWarning.GetText().Contains("Password is required."), Is.True);

        }
        [Test]
        public void AuthenticationFailureIncorectErrorMessage()
        {
            HeaderPage.SingInButton.Click();

            AuthenticationPage.SingPasswordField.SentValue("Secret_sauce0823");
            AuthenticationPage.SingInButton.Click();

            Assert.That(AuthenticationPage.EmptyEmailOrPasswordWarning.ElementDisplayed() &&
              AuthenticationPage.EmptyEmailOrPasswordWarning.GetText().Contains("Authentication failed."), Is.False);
        }
    }
}
