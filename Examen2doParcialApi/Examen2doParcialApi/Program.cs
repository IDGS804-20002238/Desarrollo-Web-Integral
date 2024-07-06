using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Examen2doParcialApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Configuración para SQL Server
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnTareas")));

// Añadir servicios de controladores
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nombre de tu API", Version = "v1" });
});

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder
            .WithOrigins("http://localhost:4200") // Dirección de tu frontend
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Habilitar middleware para servir Swagger-ui (HTML, JS, CSS, etc.)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nombre de tu API V1");
    // Opcionalmente, puedes configurar otros parámetros de SwaggerUI
    // c.RoutePrefix = "api/docs"; // Cambia la ruta de acceso de SwaggerUI si es necesario
});

// Habilitar CORS
app.UseCors("AllowFrontend");

// Endpoint de prueba para probar la conexión a la base de datos y devolver "Hola Mundo"
app.MapGet("/", async () =>
{
    return "Api Corriendo";
});

// Endpoint para probar la conexión a la base de datos
app.MapGet("/dbconnection", async ([FromServices] MyDbContext dbContext) =>
{
    try
    {
        await dbContext.Database.OpenConnectionAsync(); // Intenta abrir la conexión
        return Results.Ok("Conexión exitosa a la base de datos SQL Server.");
    }
    catch (Exception ex)
    {
        return Results.BadRequest("Error al conectar con la base de datos: " + ex.Message);
    }
    finally
    {
        await dbContext.Database.CloseConnectionAsync(); // Cierra la conexión al finalizar
    }
});

// Registro de controladores
app.MapControllers();

app.Run();

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<tipoProducto> tipoProducto { get; set; }
    public DbSet<productos> productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<productos>(entity =>
        {
            entity.HasKey(e => e.ProductoId);

            entity.Property(e => e.ProductoId).HasColumnName("PruductoId");
            entity.Property(e => e.NombreProducto).IsRequired().HasMaxLength(255);
            entity.Property(e => e.DescripcionProducto).IsRequired().HasMaxLength(255);
            entity.Property(e => e.TipoProducto).IsRequired();
            entity.Property(e => e.PrecioProducto).IsRequired();
        });
    }

}
