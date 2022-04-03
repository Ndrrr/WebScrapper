namespace WebScrapper.Data
{
    public class TapAzProduct : Product
    {
        protected string CreationDate;
        public TapAzProduct() : base()
        {
            this.CreationDate = "Not Found";
        }
        public TapAzProduct(string Title, string Price, string CreationDate)
        {
            this.Title = Title;
            this.CreationDate = CreationDate;
            this.Price = Price;
        }
        public override List<string> GetProductData()
        {
            List<string> productData = new List<string>();
            productData.Add(this.Title);
            productData.Add(this.Price);
            productData.Add(this.CreationDate);
            return productData;
        }
    }
}
