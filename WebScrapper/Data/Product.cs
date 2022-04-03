namespace WebScrapper.Data
{
    public abstract class Product
    {
        protected string Price;
        protected string Title;
        public Product()
        {
            this.Price = this.Title = "Not Found";
        }

        public abstract List<string> GetProductData();
    }
    
}


