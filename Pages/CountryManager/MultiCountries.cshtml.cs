using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TourismApp.Pages.CountryManager
{
    public class MultiCountriesModel : PageModel
    {
        [BindProperty]
        public List<InputModel> Countries { get; set; } = new();

        public void OnGet()
        {
            for (int i = 0; i < 5; i++)
            {
                Countries.Add(new InputModel());
            }
        }

        public void OnPost()
        {
        }

        public class InputModel
        {
            public string? CountryName { get; set; }
            public string? CountryCode { get; set; }
        }
    }
}