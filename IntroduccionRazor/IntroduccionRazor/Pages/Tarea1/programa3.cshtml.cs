using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages.Tarea1
{
    public class programa3Model : PageModel
    {
        [BindProperty]
        public double A { get; set; }
        [BindProperty]
        public double B { get; set; }
        [BindProperty]
        public double X { get; set; }
        [BindProperty]
        public double Y { get; set; }
        [BindProperty]
        public int N { get; set; }
        public double Resultado { get; set; }
        public bool ResultadoCalculado { get; set; } = false;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            double baseExpresion = (A * X) + (B * Y);
            Resultado = Potencia(baseExpresion, N);
            ResultadoCalculado = true;
        }

        private double Potencia(double baseNum, int exponente)
        {
            double resultado = 1;
            for (int i = 0; i < exponente; i++)
            {
                resultado *= baseNum;
            }
            return resultado;
        }
    }
}
