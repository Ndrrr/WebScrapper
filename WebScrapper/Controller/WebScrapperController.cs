using OpenQA.Selenium;
using WebScrapper.Data;
using WebScrapper.GetData;

namespace WebScrapper.Controller
{
    public static class WebScrapperController
    {
        
        static IDictionary<int, string> xPaths = new Dictionary<int, string>()
        {
            {0,"//input[@id='twotabsearchtextbox']" },
            {1, "//input[@class='query']" },
            {2, "//input[@class='search-box']" }
            
        };
        static IDictionary<int, string> URLs = new Dictionary<int, string>()
        {
            {0,"https://amazon.com/" },
            {1,"https://tap.az/" },
            {2, "https://trendyol.com" }
        };


        public static List<Product> GetResult(string productForSearch, int webSiteInd) {
            IWebDriver driver = BrowserUtils.StartBrowser();
            
            ProductFinder finder;
            if(webSiteInd == 0)
            {
                finder = new ProductFinderAmazon(URLs[webSiteInd],xPaths[webSiteInd]);
            }
            else if (webSiteInd == 1)
            {
                finder = new ProductFinderTapAz(URLs[webSiteInd], xPaths[webSiteInd]);
            }
            else
            {
                finder = new ProductFinderTrendyol(URLs[webSiteInd], xPaths[webSiteInd]);
            }
            finder.Initialize(driver);
            finder.Search(driver, productForSearch);
            List<Product> products = finder.GetProducts(driver,10);
            Console.WriteLine("Products found");

            driver.Dispose();
            return products;
        } 
    }
}
