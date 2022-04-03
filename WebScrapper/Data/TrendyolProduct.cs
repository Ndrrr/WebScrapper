namespace WebScrapper.Data
{
    public class TrendyolProduct : Product
    {
        protected string Rating;
        public TrendyolProduct() : base()
        {
            this.Title = this.Price = this.Rating = "Not Found";
        }
        public TrendyolProduct(string Title, string Price, string Rating)
        {
            this.Title = Title;
            this.Rating = Rating;
            this.Price = Price;
        }
        public override List<string> GetProductData()
        {
            List<string> productData = new List<string>();
            productData.Add(this.Title);
            productData.Add(this.Price);
            productData.Add(this.Rating);
            return productData;
        }

    }
}