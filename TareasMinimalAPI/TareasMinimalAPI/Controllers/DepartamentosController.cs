using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMinimalAPI.DTOs;
using TareasMinimalAPI.models;


namespace TareasMinimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private readonly TareasContext _context;

        public DepartamentosController(TareasContext context)
        {
            _context = context;
        }

        // GET: api/Departamentos/GetDepartamentos
        [HttpGet("GetDepartamentos")]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            var departamentos = await _context.Departamentos.ToListAsync();
            return Ok(departamentos);
        }

        [HttpPost("InsertDepartamento")]
        public async Task<ActionResult<Departamento>> InsertDepartamento([FromBody] DepartamentoDTO departamentoDto)
        {
            var departamento = new Departamento
            {
                Nombre = departamentoDto.Nombre,
                Descripcion = departamentoDto.Descripcion
            };

            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            return Ok("Departamento insertado correctamente.");
        }

        // PUT: api/Departamentos/UpdateDepartamento/5
        [HttpPut("UpdateDepartamento/{id}")]
        public async Task<IActionResult> UpdateDepartamento(int id, [FromBody] DepartamentoDTO departamentoDto)
        {

            var departamentoToUpdate = await _context.Departamentos.FindAsync(id);
            if (departamentoToUpdate == null)
            {
                return NotFound("Departamento no encontrado.");
            }

            departamentoToUpdate.Nombre = departamentoDto.Nombre;
            departamentoToUpdate.Descripcion = departamentoDto.Descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
                {
                    return NotFound("Departamento no encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Departamento actualizado correctamente.");
        }


        // DELETE: api/Departamentos/DeleteDepartamento/5
        [HttpDelete("DeleteDepartamento/{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound("Departamento no encontrado.");
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();

            return Ok("Departamento eliminado correctamente.");
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.DepartamentoId == id);
        }
    }
}
