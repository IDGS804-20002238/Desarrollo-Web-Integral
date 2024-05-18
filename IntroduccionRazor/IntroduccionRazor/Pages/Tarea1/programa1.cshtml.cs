using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages.Tarea1
{
    public class programa1Model : PageModel
    {
        [BindProperty]
        public double Peso { get; set; }
        [BindProperty]
        public double AlturaCm { get; set; }
        public double IMC { get; set; }
        public string Clasificacion { get; set; }
        public bool IMCCalculado { get; set; } = false;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            double alturaM = AlturaCm / 100; // Convertir cm a metros
            IMC = Peso / (alturaM * alturaM);

            if (IMC < 18)
            {
                Clasificacion = "Peso Bajo";
            }
            else if (IMC >= 18 && IMC < 25)
            {
                Clasificacion = "Peso Normal";
            }
            else if (IMC >= 25 && IMC < 27)
            {
                Clasificacion = "Sobrepeso";
            }
            else if (IMC >= 27 && IMC < 30)
            {
                Clasificacion = "Obesidad grado I";
            }
            else if (IMC >= 30 && IMC < 40)
            {
                Clasificacion = "Obesidad grado II";
            }
            else
            {
                Clasificacion = "Obesidad grado III";
            }

            IMCCalculado = true;
        }
    }
}
