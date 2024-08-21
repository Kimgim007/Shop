using NUnit.Allure.Core;
using Shop.WebDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tests
{
    [AllureNUnit]
    internal class BaseTest
    {
        public const string BaseUrl = "http://prestashop.qatestlab.com.ua/ru/";
        [SetUp]
        public void SetUp()
        {
            Driver.GetDriver().Navigate().GoToUrl(BaseUrl);
        }
        [TearDown]
        public void TearDown()
        {
            Driver.TeareDown();
        }
    }
}
