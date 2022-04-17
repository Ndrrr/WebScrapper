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

            ProductFinder finder=null;
            List<Product> products = new List<Product>();//finder.GetProducts(driver,10);

            if (webSiteInd >=4)
            {
                finder = new ProductFinderAmazon(URLs[0],xPaths[0]);
                webSiteInd -= 4;
                finder.Initialize(driver);
                finder.Search(driver, productForSearch);
                products = products.Concat(finder.GetProducts(driver, 10)).ToList();
            }
            if (webSiteInd >= 2)
            {
                finder = new ProductFinderTapAz(URLs[1], xPaths[1]);
                webSiteInd -= 2;
                finder.Initialize(driver);
                finder.Search(driver, productForSearch);
                products = products.Concat(finder.GetProducts(driver, 10)).ToList();
            }
            if (webSiteInd>=1)
            {
                finder = new ProductFinderTrendyol(URLs[2], xPaths[2]);
                finder.Initialize(driver);
                finder.Search(driver, productForSearch);
                products = products.Concat(finder.GetProducts(driver, 10)).ToList();
            }
        
            
            Console.WriteLine("Products found");

            driver.Dispose();
            return products;
        } 
    }
}
