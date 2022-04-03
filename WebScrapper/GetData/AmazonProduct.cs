namespace WebScrapper.GetData
{
    public class AmazonProduct : Product
    {
        public AmazonProduct()
        {
            this.Title = this.Price = this.Rating = this.Seller = "Not Found";
        }
        public AmazonProduct(string Title, string Price, string Rating, string Seller)
        {
            this.Title = Title;
            this.Price = Price;
            this.Rating = Rating;
            this.Seller = Seller;
        }

    }
}
