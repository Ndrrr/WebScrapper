using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace WebScrapper.GetData
{
    public class ProductFinderTrendyol : ProductFinder
    {
        public ProductFinderTrendyol(string URL, string searchBarXpath) : base(URL, searchBarXpath)
        {
        }
        public override void ExtraRequirements(IWebDriver driver)
        {
            System.Threading.Thread.Sleep(4000);
            SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath("//select")));

            //select by value
            selectElement.SelectByValue("TR");
            IWebElement button = driver.FindElement(By.XPath("//button"));
            button.Click();


        }
        public override List<Product> GetProducts(IWebDriver driver)
        {
            string productsXpath = "//div[contains(concat(' ',normalize-space(@class),' '),' products-i ')]";
            string priceValueXpath = "//span[@class='price-val']";
            string priceCurXpath = "//span[@class='price-cur']";
            string titleXpath = "//div[@class='products-name']";
            string CreationXpath = "//div[@class='products-created']";
            

            int productsCount = 0, curInd = 0;

            while (productsCount < 10)
            {
                string title, price = "1", creationDate = "1";
                try
                {

                    title = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + titleXpath)).GetAttribute("innerHTML");
                    price = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + priceValueXpath)).GetAttribute("innerHTML");
                    price += driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + priceCurXpath)).GetAttribute("innerHTML"); ;
                    creationDate = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + CreationXpath)).GetAttribute("innerHTML");
                    productsCount++;
                    this.Products.Add(new Product(title, price, creationDate));
                    Console.WriteLine(productsCount);
                }
                catch
                {
                    Console.WriteLine("err");
                }
                curInd++;
            }
            return this.Products;
        }
    }
}