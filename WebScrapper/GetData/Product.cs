﻿namespace WebScrapper.GetData
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

        public string? CreationDate;
        public string Title;
        public string Price;
        public string? Rating;
        public string? Seller;
    }
}
