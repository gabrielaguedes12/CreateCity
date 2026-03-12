using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TourismApp.Pages.Notes
{
    public class SaveNoteModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public SaveNoteModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? FilePath { get; set; }

        public class InputModel
        {
            public string? Content { get; set; }
        }

        public void OnPost()
        {
            var folder = Path.Combine(_environment.WebRootPath, "files");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            var fileName = $"note-{DateTime.Now.Ticks}.txt";

            var fullPath = Path.Combine(folder, fileName);

            System.IO.File.WriteAllText(fullPath, Input.Content ?? "");

            FilePath = $"/files/{fileName}";
        }
    }
}