using Microsoft.EntityFrameworkCore;
using TareasMinimalAPI.models;

namespace TareasMinimalAPI
{
    public class TareasContext : DbContext
    {
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<EmpleadoDepartamento> EmpleadoDepartamentos { get; set; }
        public DbSet<LoginMobile> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de relaciones y restricciones aquí
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Ciudad)
                .WithMany()
                .HasForeignKey(e => e.CiudadId);

            modelBuilder.Entity<EmpleadoDepartamento>()
                .HasKey(ed => new { ed.EmpleadoId, ed.DepartamentoId });

            modelBuilder.Entity<EmpleadoDepartamento>()
                .HasOne(ed => ed.Empleado)
                .WithMany(e => e.EmpleadoDepartamentos)
                .HasForeignKey(ed => ed.EmpleadoId);

            modelBuilder.Entity<EmpleadoDepartamento>()
                .HasOne(ed => ed.Departamento)
                .WithMany(d => d.EmpleadoDepartamentos)
                .HasForeignKey(ed => ed.DepartamentoId);
        }
    }
}
