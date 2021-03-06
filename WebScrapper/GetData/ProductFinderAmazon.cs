using OpenQA.Selenium;
using WebScrapper.Data;
using WebScrapper.Controller;

namespace WebScrapper.GetData
{
    public class ProductFinderAmazon : ProductFinder
    {
        public ProductFinderAmazon(string URL, string searchBarXpath) : base(URL, searchBarXpath)
        {
        }

        
        public override void FindProducts(IWebDriver driver, int count)
        {
            int currentIndex = 0;
            int currentProductCount = 0;
            string nextPageXpath = "//a[@class='s-pagination-item s-pagination-next s-pagination-button s-pagination-separator']";
            while (currentProductCount < count)
            {
                if (currentIndex % 16 == 0)
                {
                    driver.Navigate().GoToUrl(driver.FindElement(By.XPath(nextPageXpath)).GetAttribute("href"));
                }
                Console.WriteLine("Current index: " + currentIndex + " Current product count: " + currentProductCount);
                string prod_xpath = "";
                try
                {
                    prod_xpath = $"//div[@data-cel-widget='search_result_{currentIndex%16}'][@data-uuid]";
                    driver.FindElement(By.XPath(prod_xpath));
                }
                catch
                {
                    currentIndex++;
                    continue;
                }
                if (prod_xpath == "")
                {
                    currentIndex++;
                    continue;
                }
                BrowserUtils.Wait(driver, prod_xpath);

                string title = GetItem(driver, $"{prod_xpath}//span[@class='a-size-medium a-color-base a-text-normal']", 0);
                if (String.IsNullOrEmpty(title) || String.IsNullOrWhiteSpace(title)) title = GetItem(driver, $"{prod_xpath}//span[@class='a-size-base-plus a-color-base a-text-normal']", 0);
                string price = GetPrice(driver, prod_xpath);
                if (price == "Not Defined")
                {
                    currentIndex++;
                    continue;
                }
                string star = GetStar(driver, prod_xpath);


                string seller = GetItem(driver, $"{prod_xpath}//div[@class='a-row a-size-base a-color-secondary']//span");
                this.Products.Add(new AmazonProduct(title, price, star, seller));
                currentProductCount++; currentIndex++;
            }
        }

        private static string GetStar(IWebDriver driver, string xPath)
        {
            string star = "";
            try
            {
                star = driver.FindElement(By.XPath($"{xPath}//span[@class='a-icon-alt']")).GetAttribute("innerHTML");
            }
            catch
            {
                star = "The rating is not defined";
            }

            return star;
        }
        private static string GetPrice(IWebDriver driver, string xPath)
        {

            string price = "";
            try
            {
                price = driver.FindElement(By.XPath($"{xPath}//span[@class='a-price']//span[@class='a-offscreen']")).GetAttribute("innerHTML");
            }
            catch
            {
                price = "Not Defined";
            }
            return price;
        }

        private static string GetItem(IWebDriver driver, string xpath, int type = 0)
        {
            try
            {
                var arr = driver.FindElements(By.XPath(xpath));
                string tmp = "";
                foreach (var elem in arr)
                {
                    tmp += elem.Text + " ";
                    if (type == 1) tmp += '\n' + elem.FindElement(By.XPath("./..")).GetAttribute("href") + " ";
                }
                return tmp;
            }
            catch
            {
                return "";
            }
        }
    }
}