namespace WebScrapper.Data
{
    public abstract class Product
    {
        public string Price;
        protected string Title;
        public int productType;
        public Product()
        {
            this.Price = this.Title = "Not Found";
            this.productType = -1;
        }

        public abstract List<string> GetProductData();
        public string GetProductType()
        {
            if (this.productType == 4) return "amazon";
            if (this.productType == 2) return "tapaz";
            if (this.productType == 1)return "trendyol";
            return "not-defined";
        }
        public abstract string PriceConverter();
    }
    
}


