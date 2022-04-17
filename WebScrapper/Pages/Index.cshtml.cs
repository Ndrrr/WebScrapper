using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebScrapper.Data;
using WebScrapper.Controller;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebScrapper.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Product> Products;
        public bool flag;
        public string websiteIDs;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Products = new List<Product>();
            flag = false;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            Console.WriteLine(Request.Form["DesiredProduct"]);
            HandleSearch();
           
        }

        void HandleSearch()
        {
            string productName = Request.Form["DesiredProduct"];
            websiteIDs = Request.Form["website"];
            int websites = 0;
            foreach (var val in websiteIDs.Split(','))
            {
                websites += int.Parse(val);
            }
            Products = WebScrapperController.GetResult(productName, websites);
            flag = true;
        }
      
        
    }
}