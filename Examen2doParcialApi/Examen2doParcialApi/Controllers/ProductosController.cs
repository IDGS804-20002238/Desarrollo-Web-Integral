using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Examen2doParcialApi.Models;

namespace Examen2doParcialApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductosController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetProductos")]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _context.productos.ToListAsync();
            return Ok(productos);
        }

        [HttpGet("GetProductosFiltro")]
        public async Task<IActionResult> GetProductosFiltro([FromQuery] string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
            {
                return BadRequest("El filtro no puede estar vacío");
            }

            int.TryParse(filtro, out int filtroPrecio);

            var productos = await _context.productos
                .Where(p => p.NombreProducto.Contains(filtro) ||
                            p.DescripcionProducto.Contains(filtro) ||
                            p.PrecioProducto == filtroPrecio)
                .ToListAsync();

            return Ok(productos);
        }

        [HttpGet("GetCategoriaFiltro")]
        public async Task<IActionResult> GetCategoriaFiltro([FromQuery] string filtro)
        {
            if (string.IsNullOrEmpty(filtro))
            {
                return BadRequest("El filtro no puede estar vacío");
            }

            int.TryParse(filtro, out int tipoProducto);

            var productos = await _context.productos
                .Where(p => p.TipoProducto == tipoProducto)
                .ToListAsync();

            return Ok(productos);
        }

    }
}

