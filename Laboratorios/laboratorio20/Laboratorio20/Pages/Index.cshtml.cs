using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Laboratorio20.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        [BindProperty]
        public int Numero { get; set; }          // Número que ingresa el usuario

        public List<string> Tabla { get; set; } = new List<string>();   // Aquí guardamos la tabla

       

        public void OnPost()
        {
            // Generar la tabla de multiplicar desde 1 hasta 25
            Tabla.Clear();
            for (int i = 1; i <= 25; i++)
            {
                Tabla.Add($"{Numero} x {i} = {Numero * i}");
            }
        }

    }
    }

