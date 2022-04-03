using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

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
            try
            {
                SelectElement selectElement = new SelectElement(driver.FindElement(By.XPath("//select")));

                //select by value
                selectElement.SelectByValue("TR");
                IWebElement button = driver.FindElement(By.XPath("//button"));
                button.Click();
            }
            catch
            {

            }

            try
            {
                IWebElement countrySelect = driver.FindElement(By.XPath("//div[@class='country-wrapper']"));
                countrySelect.Click();
                countrySelect = driver.FindElement(By.XPath("//div[@class='select-header']"));
                countrySelect.Click();
                countrySelect = driver.FindElement(By.XPath("//li[@class='dropdown-item']"));
                countrySelect.Click();
                countrySelect = driver.FindElement(By.XPath("//button[@class='submit']"));
                countrySelect.Click();
            }
            catch
            {

            }


        }
        public override void FindProducts(IWebDriver driver, int count)
        {
            string productsXpath = "//div[@class='p-card-wrppr']";
            string priceValueXpath = "//div[@class='prc-box-dscntd']";
            string titleXpath = "//span[contains(concat(' ',normalize-space(@class),' '),' prdct-desc-cntnr-name ')]";
            string preTitleXpath = "//span[contains(concat(' ',normalize-space(@class),' '),' prdct-desc-cntnr-ttl ')]";
            string ratingCountXpath = "//span[@class='ratingCount']";
            

            int productsCount = 0, curInd = 0;

            while (productsCount < count)
            {
                string title, price = "1", rating = "1";
                try
                {
                    title = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + preTitleXpath)).GetAttribute("innerHTML")+ " ";
                    title += driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + titleXpath)).GetAttribute("innerHTML");
                    Console.WriteLine(title);
                    price = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + priceValueXpath)).GetAttribute("innerHTML");
                    rating = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + ratingCountXpath)).GetAttribute("innerHTML");

                    productsCount++;
                    rating = rating.Split('(')[1];
                    rating = rating.Split(')')[0];
                    Console.WriteLine(rating);
                    this.Products.Add(new TrendyolProduct(title, price,rating ));
                }
                catch
                {
                    Console.WriteLine("err");
                }
                curInd++;
            }
        }
    }
}