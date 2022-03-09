using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Linq;

namespace GetData
{
    public static class Run
    {
        
        static IDictionary<int, string> xPaths = new Dictionary<int, string>()
        {
            {0,"//input[@id='twotabsearchtextbox']" },
            {1, "//input[@class='query']" },
            {2, "//input[@class='mainSearchInput']" }
            
        };
        static IDictionary<int, string> URLs = new Dictionary<int, string>()
        {
            {0,"https://amazon.com/" },
            {1,"https://tap.az/" },
            {0, "https://lalafo.az" }
        };


        public static List<Product> GetResult(string productForSearch, int webSiteInd) {
            IWebDriver driver = BrowserUtils.StartBrowser();

            string searchbar_xpath = xPaths[webSiteInd];

            driver.Navigate().GoToUrl(URLs[webSiteInd]);

            BrowserUtils.Wait(driver, searchbar_xpath);


            IWebElement searchbar = driver.FindElement(By.XPath(searchbar_xpath));
            searchbar.Click();
            Console.WriteLine("Search bar is clicked");
            searchbar.SendKeys(productForSearch);
            Console.WriteLine("Keys have been sent");
            searchbar.Submit();
            Console.WriteLine("Searchbar Submit finished");

            List<Product> prodlist;
            if (webSiteInd == 0)
                prodlist = ProductFinderAmazon.GetProducts(driver);
            else
                prodlist = ProductFinderTapAz.GetProducts(driver);
            
            Console.WriteLine("Products are get");

            driver.Dispose();
            return prodlist ;
        } 
    }
}
