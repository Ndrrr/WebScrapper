namespace WebScrapper.Data
{
    public abstract class Product
    {
        protected string Price;
        protected string Title;
        public int productType;
        public Product()
        {
            this.Price = this.Title = "Not Found";
            this.productType = -1;
        }

        public abstract List<string> GetProductData();
    }
    
}


