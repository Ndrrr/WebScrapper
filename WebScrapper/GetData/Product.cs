namespace WebScrapper.GetData
{
    public class Product
    {
        public Product()
        {
            this.Title=this.Price=this.Rating=this.Seller=this.CreationDate="Not Found";
        }
        public Product(string Title, string Price, string Rating, string Seller)
        {
            this.Title = Title;
            this.Price = Price;
            this.Rating = Rating;
            this.Seller = Seller;
        }

        public Product(string Title, string Price, string CreationDate)
        {
            this.Title =(Title);
            this.Price = (Price);
            this.CreationDate = CreationDate;
        }

        public Product(string Title, string Price)
        {
            this.Title = Title;
            this.Price = Price;
        }
        public string CreationDate="Not Found";
        public string Title = "Not Found";
        public string Price = "Not Found";
        public string? Rating = "Not Found";
        public string? Seller = "Not Found";
    }
}
