using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IntroduccionRazor.Pages
{
    public class sumanumModel : PageModel
    {
        [BindProperty]
        public double Numero1 { get; set; }
        [BindProperty]
        public double Numero2 { get; set; }
        public double Suma { get; set; }
        public bool SumaCalculada { get; set; } = false;

        public void OnGet()
        {
        }

        public void OnPost()
        {
            Suma = Numero1 + Numero2;
            SumaCalculada = true;
        }
    }

}
