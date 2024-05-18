using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages.Tarea1
{
    public class programa2Model : PageModel
    {
        [BindProperty]
        public string Mensaje { get; set; }
        [BindProperty]
        public int N { get; set; }
        public string MensajeCodificado { get; set; }
        public bool EsCodificado { get; set; } = false;

        public void OnGet()
        {
        }

        public void OnPostCodificar()
        {
            MensajeCodificado = Codificar(Mensaje, N);
            EsCodificado = true;
        }

        public void OnPostDecodificar()
        {
            MensajeCodificado = Codificar(Mensaje, 26 - N);
            EsCodificado = true;
        }

        private string Codificar(string mensaje, int n)
        {
            char[] buffer = mensaje.ToUpper().ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char letra = buffer[i];
                if (char.IsLetter(letra))
                {
                    char primeraLetra = char.IsUpper(letra) ? 'A' : 'a';
                    letra = (char)((((letra + n) - primeraLetra) % 26) + primeraLetra);
                }
                buffer[i] = letra;
            }
            return new string(buffer);
        }
    }
}
