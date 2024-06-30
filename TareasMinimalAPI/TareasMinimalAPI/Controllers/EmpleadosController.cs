using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TareasMinimalAPI.models;

namespace TareasMinimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly TareasContext _context;

        public EmpleadosController(TareasContext context)
        {
            _context = context;
        }

        // GET: api/Empleados/getEmpleados
        [HttpGet("getEmpleados")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados.Include(e => e.Ciudad).ToListAsync();
        }

        // POST: api/Empleados/insertaEmpleado
        [HttpPost("insertaEmpleado")]
        public async Task<IActionResult> InsertaEmpleado([FromBody] EmpleadoDto empleadoDto)
        {
            try
            {
                var empleado = new Empleado
                {
                    Nombre = empleadoDto.Nombre,
                    FechaIngreso = empleadoDto.FechaIngreso,
                    Puesto = empleadoDto.Puesto,
                    Sueldo = empleadoDto.Sueldo,
                    CiudadId = empleadoDto.CiudadId
                };

                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();

                int empleadoId = empleado.EmpleadoId;

                var empleadoDepartamento = new EmpleadoDepartamento
                {
                    EmpleadoId = empleadoId,
                    DepartamentoId = empleadoDto.DepartamentoId
                };

                _context.EmpleadoDepartamentos.Add(empleadoDepartamento);
                await _context.SaveChangesAsync();

                return Ok("Empleado y EmpleadoDepartamentos insertados correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar empleado: {ex.Message}");
            }
        }

        // PUT: api/Empleados/updateEmpleado/5
        [HttpPut("updateEmpleado/{id}")]
        public async Task<IActionResult> UpdateEmpleado(int id, [FromBody] EmpleadoDto empleadoDto)
        {

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound($"No se encontró ningún empleado con ID {id}.");
            }

            // Actualizar propiedades permitidas (Nombre, FechaIngreso, Puesto, Sueldo, CiudadId)
            empleado.Nombre = empleadoDto.Nombre;
            empleado.FechaIngreso = empleadoDto.FechaIngreso;
            empleado.Puesto = empleadoDto.Puesto;
            empleado.Sueldo = empleadoDto.Sueldo;
            empleado.CiudadId = empleadoDto.CiudadId;

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Empleado actualizado correctamente.");
        }


        // DELETE: api/Empleados/deleteEmpleado/5
        [HttpDelete("deleteEmpleado/{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                var empleado = await _context.Empleados.FindAsync(id);
                if (empleado == null)
                {
                    return NotFound($"No se encontró ningún empleado con ID {id}.");
                }

                // Eliminar todos los registros relacionados en EmpleadoDepartamentos
                var empleadoDepartamentos = _context.EmpleadoDepartamentos.Where(ed => ed.EmpleadoId == id);
                _context.EmpleadoDepartamentos.RemoveRange(empleadoDepartamentos);

                // Eliminar el empleado
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();

                return Ok($"Empleado con ID {id} ha sido eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar empleado con ID {id}: {ex.Message}");
            }
        }



        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.EmpleadoId == id);
        }
    }
}
