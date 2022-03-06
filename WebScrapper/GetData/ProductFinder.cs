using OpenQA.Selenium;

namespace GetData
{
    public static class ProductFinder
    {
        static IDictionary<int, List<string>> xPaths = new Dictionary<int, List<string>>()
        {
            {0,new List<string>(){ "//div[@data-cel-widget='search_result_", "'][@data-uuid]",
                "//span[@class='a-size-medium a-color-base a-text-normal']","//span[@class='a-size-base-plus a-color-base a-text-normal']",
                "//div[@class='a-row a-size-base a-color-secondary']//span","//span[@class='a-icon-alt']","//span[@class='a-price']//span[@class='a-offscreen']"
            } }
        };
        public static List<Product> GetProducts(IWebDriver driver, int webSiteInd)
        {
            List<Product> prodlist = new List<Product>();
            int currentIndex = 0;
            int currentProductCount = 0;
            while (currentProductCount != 10)
            {
                string prod_xpath = "";
                try
                {
                    prod_xpath = xPaths[webSiteInd][0]+$"{currentIndex}"+xPaths[webSiteInd][1];
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

                string title = GetItem(driver, $"{prod_xpath}{xPaths[webSiteInd][2]}", 0);
                if (String.IsNullOrEmpty(title) || String.IsNullOrWhiteSpace(title)) title = GetItem(driver, $"{prod_xpath}{xPaths[webSiteInd][3]}", 0);
                string price = GetPrice(driver, prod_xpath, webSiteInd);
                string star = GetStar(driver, prod_xpath,webSiteInd);


                string seller = GetItem(driver, $"{prod_xpath}{xPaths[webSiteInd][4]}");
                prodlist.Add(new Product(title, price,star, seller));
                currentProductCount++; currentIndex++;
            }
            return prodlist;
        }

        private static string GetStar(IWebDriver driver, string xPath, int webSiteInd)
        {
            string star = "";
            try
            {
                star = driver.FindElement(By.XPath($"{xPath}{xPaths[webSiteInd][5]}")).GetAttribute("innerHTML");
            }
            catch
            {
                star = "The rating is not defined";
            }

            return star;
        }
        private static string GetPrice(IWebDriver driver, string xPath, int webSiteInd)
        {

            string price = "";
            try
            {
                price = driver.FindElement(By.XPath($"{xPath}{xPaths[webSiteInd][6]}")).GetAttribute("innerHTML");
            }
            catch
            {
                price = "The price is not defined";
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