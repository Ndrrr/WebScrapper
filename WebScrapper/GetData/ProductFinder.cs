using OpenQA.Selenium;
using WebScrapper.Data;
using WebScrapper.Controller;

namespace WebScrapper.GetData
{
    public abstract class ProductFinder
    {
        protected List<Product> Products;
        protected string? URL;
        protected string? searchBarXpath;

        public ProductFinder()
        {
            Products = new List<Product>();
        }
        public ProductFinder(string URL, string searchBarXpath)
        {
            Products = new List<Product>();
            this.URL = URL;
            this.searchBarXpath = searchBarXpath;
        }
        public void Initialize(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(this.URL);
        }
        public virtual void ExtraRequirements(IWebDriver driver)
        {

        }

        public void Search(IWebDriver driver, string productForSearch)
        {
            BrowserUtils.Wait(driver, this.searchBarXpath);
            ExtraRequirements(driver);
            IWebElement searchbar = driver.FindElement(By.XPath(this.searchBarXpath));
            searchbar.Click();
            Console.WriteLine("Search bar is clicked");
            searchbar.SendKeys(productForSearch);
            Console.WriteLine("Keys have been sent");
            try
            {
                searchbar.Submit();
            }
            catch
            {
                System.Threading.Thread.Sleep(1000);
                driver.FindElement(By.XPath("//a[@class='suggestion']")).Click();
            }
            Console.WriteLine("Searchbar Submit finished");
        }
        public abstract void FindProducts(IWebDriver driver, int count);

        public List<Product> GetProducts(IWebDriver driver, int count)
        {
            FindProducts(driver,count);
            return this.Products;
        }
    }
}
