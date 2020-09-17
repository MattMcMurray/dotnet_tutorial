using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;

        public ListModel(IConfiguration config) {
            this.config = config;
        }

        public string Message { get; set; }
        public void OnGet()
        {
            Message = config["Message"];
        }
    }
}
