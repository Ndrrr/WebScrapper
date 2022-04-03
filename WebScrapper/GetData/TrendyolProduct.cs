namespace WebScrapper.GetData
{
    public class TrendyolProduct : Product
    {
        public TrendyolProduct() : base()
        {
            this.Title = this.Price = this.Rating = "Not Found";
        }
        public TrendyolProduct(string Title, string Price, string Rating)
        {
            this.Title = Title;
            this.Rating = (Rating);
            this.Price = Price;
        }
    }
}