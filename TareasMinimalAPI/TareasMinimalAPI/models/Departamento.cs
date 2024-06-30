namespace TareasMinimalAPI.models
{
    public class Departamento
    {
        public int DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Relación con EmpleadoDepartamento
        public virtual ICollection<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; }
    }
}
