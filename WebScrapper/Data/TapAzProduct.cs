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
            this.productType = 2;
        }
        
        public override List<string> GetProductData()
        {
            List<string> productData = new List<string>();
            productData.Add(this.Title);
            productData.Add(this.Price);
            productData.Add("-");
            productData.Add("Creation Date: "+this.CreationDate);
            return productData;
        }
        public override string PriceConverter()
        {
            return this.Price;  
        }
    }
}
