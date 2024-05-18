using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages.Tarea1
{
    public class programa4Model : PageModel
    {
        public List<int> Numeros { get; set; }
        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; }
        public double Mediana { get; set; }
        public bool ResultadosCalculados { get; set; } = false;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var random = new Random();
            Numeros = Enumerable.Range(0, 20).Select(x => random.Next(0, 101)).ToList();

            Suma = Numeros.Sum();
            Promedio = Numeros.Average();

            // Cálculo de la moda
            var grupos = Numeros.GroupBy(n => n)
                                .Select(grp => new { Numero = grp.Key, Conteo = grp.Count() })
                                .OrderByDescending(g => g.Conteo)
                                .ToList();
            int maxConteo = grupos.First().Conteo;
            Moda = grupos.Where(g => g.Conteo == maxConteo).Select(g => g.Numero).ToList();

            // Cálculo de la mediana
            var numerosOrdenados = Numeros.OrderBy(n => n).ToList();
            if (numerosOrdenados.Count % 2 == 0)
            {
                Mediana = (numerosOrdenados[numerosOrdenados.Count / 2 - 1] + numerosOrdenados[numerosOrdenados.Count / 2]) / 2.0;
            }
            else
            {
                Mediana = numerosOrdenados[numerosOrdenados.Count / 2];
            }

            ResultadosCalculados = true;
        }
    }
}
