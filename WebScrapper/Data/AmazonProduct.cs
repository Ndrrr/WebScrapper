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
        public override string PriceConverter()
        {
            string tmp = this.Price.Split("$")[1].Split(".")[0];
            double tmpp = Convert.ToDouble(tmp);
            tmpp *= 1.7;
            tmpp = Convert.ToInt32(tmpp);
            return String.Format("{0:0.00}",tmpp.ToString())+"AZN";
        }
    }
}
