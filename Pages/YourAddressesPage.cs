using OpenQA.Selenium;
using Shop.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Pages
{
    internal class YourAddressesPage
    {
        public static Element FirstName => new Element(By.XPath("//*[@id='firstname']"));
        public static Element LastName => new Element(By.XPath("//*[@id='lastname']"));
        public static Element Company => new Element(By.XPath("//*[@id='company']"));
        public static Element Address => new Element(By.XPath("//*[@id='address1']"));
        public static Element AddressLineTwo => new Element(By.XPath("//*[@id='address2']"));
        public static Element ZipPostalCode => new Element(By.XPath("//*[@id='postcode']"));
        public static Element City => new Element(By.XPath("//*[@id='city']"));

        public static Element Country => new Element(By.XPath("//*[@id='id_country']"));

        public static Element HomePhone => new Element(By.XPath("//*[@id='phone']"));
        public static Element MobilePhone => new Element(By.XPath("//*[@id='phone_mobile']"));

        public static Element State => new Element(By.XPath("//*[@id='id_state']"));

        public static Element AdditionalInformation => new Element(By.XPath("//*[@id='other']"));
        public static Element AliasAddress => new Element(By.XPath("//*[@id='alias']"));

        public static Element SaveButton => new Element(By.XPath("//*[@id='submitAddress']"));
        

    }
}
