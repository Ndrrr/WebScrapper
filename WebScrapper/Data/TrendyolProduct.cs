namespace WebScrapper.Data
{
    public class TrendyolProduct : Product
    {
        protected string Rating;
        protected string RatingCount;
        public TrendyolProduct() : base()
        {
            this.Title = this.Price = this.Rating = "Not Found";
        }
        public TrendyolProduct(string Title, string Price, string Rating, string RatingCount)
        {
            this.Title = Title;
            this.Rating = Rating;
            this.Price = Price;
            this.RatingCount = RatingCount;
            this.productType = 1;
        }
        public override List<string> GetProductData()
        {
            List<string> productData = new List<string>();
            productData.Add(this.Title);
            productData.Add(this.Price);
            productData.Add("Rated "+this.Rating + " out of 5.0");
            productData.Add("Rated by " + this.RatingCount + " people");
            return productData;
        }

    }
}