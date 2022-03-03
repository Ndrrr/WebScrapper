using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace GetData
{
    public static class Run
    {
        public static List<Product> GetResult(string productForSearch) {
            IWebDriver driver = BrowserUtils.StartBrowser();

            string searchbar_xpath = "//input[@id='twotabsearchtextbox']";

            driver.Navigate().GoToUrl("https://amazon.com/");

            BrowserUtils.Wait(driver, searchbar_xpath);


            IWebElement searchbar = driver.FindElement(By.XPath(searchbar_xpath));
            searchbar.Click();
            Console.WriteLine("Search bar is clicked");
            searchbar.SendKeys(productForSearch);
            searchbar.Submit();

            List<Product> prodlist = ProductFinder.GetProducts(driver);
            Console.WriteLine("Products are get");

            driver.Dispose();
            return prodlist ;
        } 
    }
}
