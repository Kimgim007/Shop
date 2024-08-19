using OpenQA.Selenium;
using Shop.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class AuthenticationPage : BasePage
    {
        public static Element CreateAccountEmailField => new Element(By.XPath("//*[@id='email_create']"));
        public static Element EmptyCreateAccountEmailFieldWarning => new Element(By.XPath("//*[@id='create_account_error']"));
        public static Element EmptyCreateAccountEmailFieldWarningText => new Element(By.XPath("//*[@id='create_account_error']/ol/li"));
        
        public static Element CreateAnAccountButton => new Element(By.XPath("//*[@id='SubmitCreate']"));
      
        public static Element SignInEmailField => new Element(By.XPath("//*[@id='email']"));
        public static Element SingPasswordField => new Element(By.XPath("//*[@id='passwd']"));
        public static Element SingInButton => new Element(By.XPath("//*[@id='SubmitLogin']"));
        public static Element EmptyEmailOrPasswordWarning => new Element(By.XPath("//*[@id='center_column']/div[1]"));


        public static void Login()
        {
            Assert.That(HeaderPage.SingInButton.ElementDispleed(), Is.True);
            HeaderPage.SingInButton.Click();

            SignInEmailField.SentValue(login);
            SingPasswordField.SentValue(password);
            SingInButton.Click();
        }
        
    }
}
