using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Mvc;

namespace MvcMovies.Controllers
{
    public class HelloWorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Welcom(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hola " + name;
            ViewData["NumTimes"] = numTimes;

            
            return View();
        }
    }
}
