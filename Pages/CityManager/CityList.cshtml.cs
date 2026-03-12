using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TourismApp.Pages.CityManager
{
    public class CityListModel : PageModel
    {
        public List<string> Cities { get; set; } =
        new List<string> { "Rio", "São Paulo", "Brasília" };

        public void OnGet()
        {
        }
    }
}