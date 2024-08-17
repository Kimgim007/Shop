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
        public static Element CreateAnAccountButton => new Element(By.XPath("//*[@id='SubmitCreate']"));
      
        public static Element SignInEmailField => new Element(By.XPath("//*[@id='email']"));
        public static Element SingPasswordField => new Element(By.XPath("//*[@id='passwd']"));
        public static Element SingInButton => new Element(By.XPath("//*[@id='SubmitLogin']"));

        
        public static void Login()
        {
            SignInEmailField.SentValue(login);
            SingPasswordField.SentValue(password);
            SingInButton.Click();
        }
    
     
    }
}
