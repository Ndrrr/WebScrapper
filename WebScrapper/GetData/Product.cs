namespace GetData
{
    public class Product
    {
        public Product()
        {
            this.Title=this.Price=this.Rating=this.Seller="";
        }
        public Product(string Title, string Price, string Rating, string Seller)
        {
            this.Title = Title;
            this.Price = Price;
            this.Rating = Rating;
            this.Seller = Seller;
        }
        public string Title;
        public string Price;
        public string Rating;
        public string Seller;
    }
}
