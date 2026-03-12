using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace TourismApp.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? Message { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade é obrigatório")]
            [MinLength(3, ErrorMessage = "A cidade deve ter no mínimo 3 caracteres")]
            public string? CityName { get; set; }
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
                return;

            Message = $"Cidade cadastrada: {Input.CityName}";
        }
    }
}