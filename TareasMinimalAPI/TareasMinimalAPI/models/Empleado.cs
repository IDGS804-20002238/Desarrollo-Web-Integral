namespace TareasMinimalAPI.models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Puesto { get; set; }
        public double Sueldo { get; set; }

        // Relación con Ciudad
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }

        // Relación con EmpleadoDepartamento
        public virtual ICollection<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; }
    }
}
