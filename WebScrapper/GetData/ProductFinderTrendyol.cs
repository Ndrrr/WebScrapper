using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebScrapper.Data;

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
            string ratingXpath = ("//div[@class='pr-rnr-sm-p']//span");
            string productHREF;
            int productsCount = 0, curInd = 0;
            bool flag = false;
            while (productsCount < count)
            {
                string title, price = "1", ratingCount = "1", rating;
                try
                {
                    title = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + preTitleXpath)).GetAttribute("innerHTML")+ " ";
                    title += driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + titleXpath)).GetAttribute("innerHTML");
                    Console.WriteLine(title);
                    price = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + priceValueXpath)).GetAttribute("innerHTML");
                    ratingCount = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + ratingCountXpath)).GetAttribute("innerHTML");

                    productHREF = driver.FindElement(By.XPath(productsXpath+$"[{curInd}]"+"//a")).GetAttribute("href");
                    Console.WriteLine(productHREF);
                    flag = true;
                    driver.Navigate().GoToUrl(productHREF);
                    System.Threading.Thread.Sleep(1000);
                    
                    rating = driver.FindElement(By.XPath(ratingXpath)).GetAttribute("innerHTML");
                    driver.Navigate().Back();
                    flag = false;


                    productsCount++;
                    ratingCount = ratingCount.Split('(')[1];
                    ratingCount = ratingCount.Split(')')[0];
                    Console.WriteLine(rating);
                    this.Products.Add(new TrendyolProduct(title, price,rating, ratingCount ));
                }
                catch
                {
                    if (flag)
                    {
                        driver.Navigate().Back();
                        flag = false;
                    }
                    Console.WriteLine("err");
                }
                curInd++;
            }
        }
    }
}