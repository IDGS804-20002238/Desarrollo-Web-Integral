namespace TareasMinimalAPI.models
{
    public class EmpleadoDepartamento
    {
        public int EmpleadoId { get; set; }
        public virtual Empleado Empleado { get; set; }

        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }
    }
}
