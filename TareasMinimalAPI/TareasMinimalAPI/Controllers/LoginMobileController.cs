using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TareasMinimalAPI.models;

namespace TareasMinimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginMobileController : Controller
    {
        private readonly TareasContext _context;

        public LoginMobileController(TareasContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginMobile>> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Usuarios
                                      .FirstOrDefaultAsync(u => u.Email == request.Email && u.Contrasenia == request.Contrasenia);

            if (user == null)
            {
                return NotFound(new { message = "Usuario o contraseña incorrectos" });
            }

            return Ok(user);
        }

        [HttpPost("insertarUsuario")]
        public async Task<ActionResult<LoginMobile>> InsertarUsuario([FromBody] LoginMobile usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(InsertarUsuario), new { id = usuario.Id }, usuario);
            }
            return BadRequest(ModelState);
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Contrasenia { get; set; }
    }
}
