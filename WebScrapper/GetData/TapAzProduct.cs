namespace WebScrapper.GetData
{
    public class TapAzProduct : Product
    {
        public TapAzProduct()
        {
            this.CreationDate = this.Price = this.Title = "Not Found";
        }
        public TapAzProduct(string Title, string Price, string CreationDate)
        {
            this.Title = Title;
            this.CreationDate = (CreationDate);
            this.Price = Price;
        }
    }
}
