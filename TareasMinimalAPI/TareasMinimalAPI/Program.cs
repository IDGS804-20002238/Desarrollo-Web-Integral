using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TareasMinimalAPI;

var builder = WebApplication.CreateBuilder(args);

// Configuración para SQL Server
builder.Services.AddDbContext<TareasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("cnTareas")));

// Añadir servicios de controladores
builder.Services.AddControllers();

var app = builder.Build();

// No forzar redirección a HTTPS
// app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

// Endpoint para probar la conexión a la base de datos
app.MapGet("/dbconnection", async ([FromServices] TareasContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

// Registro de controladores
app.MapControllers();

app.Run();
