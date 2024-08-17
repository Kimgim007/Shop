using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    internal class RegistrationTest : BaseTest
    {
        [Test]
        public void RegistrationAccount()
        {
            HomePage.SingInButton.Click();

            Assert.That(AuthenticationPage.CreateAccountEmailField.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(AuthenticationPage.CreateAccountEmailField, BasePage.login), Is.True);
            Assert.That(AuthenticationPage.CreateAnAccountButton.ElementDispleed(), Is.True);
            AuthenticationPage.CreateAnAccountButton.Click();

            RegistrationPage.RadioGender_1.Click();
            Assert.That(BasePage.WorkWithInput(RegistrationPage.RadioGender_1), Is.True);

            Assert.That(RegistrationPage.FirstNameField.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(RegistrationPage.FirstNameField, BasePage.firstName), Is.True);

            Assert.That(RegistrationPage.LastNameField.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(RegistrationPage.LastNameField, BasePage.lastName), Is.True);

            Assert.That(RegistrationPage.DetailsEmailField.ElementDispleed(), Is.True);
            Assert.That(BasePage.CheckExpectedText(RegistrationPage.DetailsEmailField, BasePage.login), Is.True);

            Assert.That(RegistrationPage.PasswordFieldForCreateAccount.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(RegistrationPage.PasswordFieldForCreateAccount, BasePage.password), Is.True);

            Assert.That(RegistrationPage.WorkWithDateOfBirth(), Is.True);
            RegistrationPage.EndCreateAnAccountButton.Click();

            Assert.That(MyAccountPage.AlertSuccess.ElementDispleed(), Is.True);

            Assert.That(MyAccountPage.AlertSuccess.GetText() == "Your account has been created.", Is.True);
        }
    }
}
