using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TourismApp.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public string? CityName { get; set; }

        public void OnGet() { }

        public void OnPost()
        {
            // o Model Binding já coloca o valor digitado em CityName
        }
    }
}