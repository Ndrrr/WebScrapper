using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebScrapper.Data;
using WebScrapper.Controller;

namespace WebScrapper.Pages
{
    public class TapAzIndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public List<Product> Products;
        public bool flag;
        public TapAzIndexModel(ILogger<IndexModel> logger)
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
            Products = WebScrapperController.GetResult(productName, 2);
            flag = true;
        }
    }
}