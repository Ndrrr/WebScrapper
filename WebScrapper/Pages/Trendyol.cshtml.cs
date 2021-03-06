using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebScrapper.Controller;
using WebScrapper.Data;

namespace WebScrapper.Pages
{
    public class TrendyolIndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Product> Products;
        public bool flag;
        public TrendyolIndexModel(ILogger<IndexModel> logger)
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
            string productName = Request.Form["DesiredProduct"];
            Products = WebScrapperController.GetResult(productName, 1);
            flag = true;
        }
    }
}