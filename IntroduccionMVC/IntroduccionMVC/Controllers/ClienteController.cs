using IntroduccionMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroduccionMVC.Controllers
{
    public class ClienteController : Controller
    {
        public static List<Cliente> ListaClientes = new
            List<Cliente>
        {
            new Cliente
            {
                Id = 1,
                Nombre = "Angel",
                FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                Correo = "angel@gmail.com"
            },
            new Cliente
            {
                Id = 2,
                Nombre = "Jose",
                FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                Correo = "jose@gmail.com"
            },
            new Cliente
            {
                Id = 3,
                Nombre = "Tovar",
                FechaAlta = DateTime.Parse(DateTime.Today.ToString()),
                Correo = "tovar@gmail.com"
            },
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pedidos()
        {
            return View();
        }

        public IActionResult ListadoClientes()
        {
            return View(ListaClientes);
        }
    }
}
