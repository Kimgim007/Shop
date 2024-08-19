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

            Assert.That(AuthenticationPage.CreateAccountEmailField.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(AuthenticationPage.CreateAccountEmailField, email), Is.True);
            Assert.That(AuthenticationPage.CreateAnAccountButton.ElementDispleed(), Is.True);
            AuthenticationPage.CreateAnAccountButton.Click();

            MyPersonalInformationPage.RadioGender_1.Click();
            Assert.That(BasePage.WorkWithInput(MyPersonalInformationPage.RadioGender_1), Is.True);

            Assert.That(MyPersonalInformationPage.FirstNameFieldForRegistration.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(MyPersonalInformationPage.FirstNameFieldForRegistration, BasePage.firstName), Is.True);

            Assert.That(MyPersonalInformationPage.LastNameFieldRegistration.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(MyPersonalInformationPage.LastNameFieldRegistration, BasePage.lastName), Is.True);

            Assert.That(MyPersonalInformationPage.DetailsEmailField.ElementDispleed(), Is.True);
            Assert.That(BasePage.CheckExpectedText(MyPersonalInformationPage.DetailsEmailField, email), Is.True);

            Assert.That(MyPersonalInformationPage.PasswordFieldForCreateAccount.ElementDispleed(), Is.True);
            Assert.That(BasePage.ClickClearEnterVerify(MyPersonalInformationPage.PasswordFieldForCreateAccount, BasePage.password), Is.True);

            Assert.That(MyPersonalInformationPage.WorkWithDateOfBirth(), Is.True);
            MyPersonalInformationPage.EndCreateAnAccountButton.Click();

            Assert.That(MyAccountPage.AlertSuccess.ElementDispleed(), Is.True);

            Assert.That(MyAccountPage.AlertSuccess.GetText() == "Your account has been created.", Is.True);
        }
        [Test]
        public void SaveButtonMyPersonalInformationFail()
        {
            AuthenticationPage.Login();
         
            Assert.That(MyAccountPage.MyPersonalInformation.ElementDispleed(), Is.True);
            MyAccountPage.MyPersonalInformation.Click();
            Assert.That(MyPersonalInformationPage.PageName.ElementDispleed(), Is.True);
            Assert.That(MyPersonalInformationPage.UpdatetAndSaveButtonYourPersonalInformation.ElementDispleed(), Is.True);
            Assert.That(MyPersonalInformationPage.UpdatetAndSaveButtonYourPersonalInformation.Clickable(), Is.True);
            MyPersonalInformationPage.UpdatetAndSaveButtonYourPersonalInformation.Click();
            Assert.That(MyPersonalInformationPage.PageName.ElementEnabled(), Is.True);
        }
    }
}
