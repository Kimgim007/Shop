using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.WebDrive;

namespace Shop.Elements
{
    public class Element
    {
        private readonly By _locator;

        private static Actions action = new Actions(Driver.GetDriver());
        public Element(By locator)
        {
            this._locator = locator;

        }

        public IWebElement webElement
        {
            get
            {
                WaitWebElementPresent();
                return Driver.GetDriver().FindElement(_locator);
            }
        }

        public void WaitWebElementPresent()
        {
            Driver.WaitDriver(Driver.GetDriver(), 20).Until(q => q.FindElements(_locator).Count > 0);
        }

        public void SentValue(string value)
        {
            ScrollToElement();
            webElement.SendKeys(value);
        }
        public string GetValue()
        {
            ScrollToElement();
            var element = webElement.GetAttribute("value");
            return element;

        }
        public bool ElementEnabled()
        {
            return webElement.Enabled;

        }

        public IList<IWebElement> FindChildElements()
        {
            ScrollToElement();
            IList<IWebElement> sortContainerElements = webElement.FindElements(By.XPath("./*"));

            return sortContainerElements;
        }
        public IList<IWebElement> FindElements()
        {
            ScrollToElement();
            IList<IWebElement> sortContainerElements = webElement.FindElements(_locator);

            return sortContainerElements;
        }
        public bool IsInputFocused()
        {
            ScrollToElement();
            bool isActive = (bool)((IJavaScriptExecutor)Driver.GetDriver()).ExecuteScript("return document.activeElement === arguments[0];", webElement);
            return isActive;
        }
        public void Click()
        {
            ScrollToElement();
            webElement.Click();
        }

        public void ScrollPane(int downPixel)
        {
            action.DragAndDropToOffset(webElement, 0, downPixel).Perform();

        }
        public void ScrollToElement()
        {
            ((IJavaScriptExecutor)Driver.GetDriver()).ExecuteScript("arguments[0].scrollIntoView(true);", webElement);

        }
        public string GetText() => webElement.Text;
        public void ClearField()
        {
            webElement.Clear();
        }
        public bool ElementDispleed()
        {
            try
            {
                return Driver.GetDriver().FindElement(_locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


    }
}
