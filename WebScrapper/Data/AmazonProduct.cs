namespace WebScrapper.Data
{
    public class AmazonProduct : Product
    {
        protected string Rating;
        protected string Seller;

        public AmazonProduct() : base()
        {
            this.Rating = this.Seller = "Not Found";
        }
        public AmazonProduct(string Title, string Price, string Rating, string Seller)
        {
            this.Title = Title;
            this.Price = Price;
            this.Rating = Rating;
            this.Seller = Seller;
            this.productType = 4;
        }

        public override List<string> GetProductData()
        {
            List<string> productData = new List<string>();
            productData.Add(this.Title);
            productData.Add(this.Price);
            productData.Add(this.Rating);
            productData.Add(this.Seller);
            return productData;
        }
    }
}
