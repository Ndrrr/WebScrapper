﻿using OpenQA.Selenium;

namespace WebScrapper.GetData
{
    public class ProductFinderTapAz:ProductFinder
    {
        public ProductFinderTapAz(string URL, string searchBarXpath) : base(URL, searchBarXpath)
        {
        }
        
        public override List<Product> GetProducts(IWebDriver driver)
        {
            string productsXpath = "//div[contains(concat(' ',normalize-space(@class),' '),' products-i ')]";
            string priceValueXpath = "//span[@class='price-val']";
            string priceCurXpath = "//span[@class='price-cur']";
            string titleXpath = "//div[@class='products-name']";
            string CreationXpath = "//div[@class='products-created']";

            int productsCount = 0,curInd=0;

            while (productsCount < 10)
            {
                string title, price="1", creationDate="1";
                try { 
                    
                    title= driver.FindElement(By.XPath(productsXpath+$"[{curInd}]"+titleXpath)).GetAttribute("innerHTML");
                    price = driver.FindElement(By.XPath(productsXpath + $"[{curInd}]" + priceValueXpath)).GetAttribute("innerHTML");
                    price+= driver.FindElement(By.XPath(productsXpath+ $"[{curInd}]" + priceCurXpath)).GetAttribute("innerHTML"); ;
                    creationDate= driver.FindElement(By.XPath(productsXpath+ $"[{curInd}]" + CreationXpath)).GetAttribute("innerHTML");
                    productsCount++;
                    this.Products.Add(new Product(title,price,creationDate));
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