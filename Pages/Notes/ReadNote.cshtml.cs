using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TourismApp.Pages.Notes
{
    public class ReadNoteModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;

        public ReadNoteModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public List<string> Files { get; set; } = new();

        public string? Content { get; set; }

        public void OnGet(string? file)
        {
            var folder = Path.Combine(_environment.WebRootPath, "files");

            if (Directory.Exists(folder))
            {
                Files = Directory.GetFiles(folder)
                    .Select(Path.GetFileName)
                    .ToList();
            }

            if (!string.IsNullOrEmpty(file))
            {
                var fullPath = Path.Combine(folder, file);

                if (System.IO.File.Exists(fullPath))
                {
                    Content = System.IO.File.ReadAllText(fullPath);
                }
            }
        }
    }
}