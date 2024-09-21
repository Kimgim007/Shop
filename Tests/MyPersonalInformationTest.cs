using NUnit.Allure.Core;
using Shop.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    [AllureNUnit]
    internal class MyPersonalInformationTest : BaseTest
    {
        [Test]
        [Order(1)]
        public void RegistrationAccount()
        {
            HeaderPage.SingInButton.Click();

            var email = MyPersonalInformationPage.GenerateRandomEmail();

            BasePage.ClickClearEnter(AuthenticationPage.CreateAccountEmailField, email);
            AuthenticationPage.CreateAnAccountButton.Click();

            MyPersonalInformationPage.RadioGender_1.Click();

            BasePage.WorkWithInput(MyPersonalInformationPage.RadioGender_1);
            BasePage.ClickClearEnter(MyPersonalInformationPage.FirstNameFieldForRegistration, BasePage.firstName);
            BasePage.ClickClearEnter(MyPersonalInformationPage.LastNameFieldRegistration, BasePage.lastName);

            var emailCorrect = BasePage.CheckExpectedText(MyPersonalInformationPage.DetailsEmailField, email);
            BasePage.ClickClearEnter(MyPersonalInformationPage.PasswordFieldForCreateAccount, BasePage.password);
            var dateOfBirthValid = MyPersonalInformationPage.WorkWithDateOfBirth();

            MyPersonalInformationPage.EndCreateAnAccountButton.Click();

            Assert.That(MyAccountPage.AlertSuccess.GetText() == "Your account has been created." && dateOfBirthValid && emailCorrect, Is.True);
        }

        [Test]
        public void SaveButtonMyPersonalInformationFail()
        {
            AuthenticationPage.Login();

            MyAccountPage.MyPersonalInformation.Click();
            BasePage.ClickClearEnter(MyPersonalInformationPage.FirstNameFieldForUpdate, "Jonii");
            MyPersonalInformationPage.UpdatetAndSaveButtonYourPersonalInformation.Click();
            HeaderPage.Account.Click();
            MyAccountPage.MyPersonalInformation.Click();

            Assert.That(MyPersonalInformationPage.FirstNameFieldForUpdate.GetText() == "Jonii", Is.False);
        }
    }
}
