using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TourismApp.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public Country? CreatedCountry { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Informe o nome do país")]
            public string? CountryName { get; set; }

            [Required(ErrorMessage = "Informe o código do país")]
            [StringLength(2, MinimumLength = 2,
            ErrorMessage = "O código deve ter exatamente 2 letras")]
            public string? CountryCode { get; set; }
        }

        public void OnPost()
        {
            if (Input.CountryName != null && Input.CountryCode != null)
            {
                if (Input.CountryName[0] != Input.CountryCode[0])
                {
                    ModelState.AddModelError(
                    "Input.CountryCode",
                    "O código do país deve começar com a mesma letra do nome.");
                }
            }

            if (!ModelState.IsValid)
                return;

            CreatedCountry = new Country
            {
                CountryName = Input.CountryName,
                CountryCode = Input.CountryCode
            };
        }

        public class Country
        {
            public string? CountryName { get; set; }
            public string? CountryCode { get; set; }
        }
    }
}