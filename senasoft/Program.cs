using Microsoft.EntityFrameworkCore;
using senasoft;
using senasoft.Data;
using senasoft.Models;
using senasoft.Repositorios.Implementacion;
using senasoft.Repositorios.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("Cadena de conexión cargada: " + connStr);

builder.Services.AddScoped<IFacMTarjeteroRepository, FacMTarjeteroRepository>();
builder.Services.AddScoped<IFacPCupRepository, FacPCupRepository>();
builder.Services.AddScoped<IFacPNivelRepository, FacPNivelRepository>();
builder.Services.AddScoped<IFacPProfesionalRepository, FacPProfesionalRepository>();
builder.Services.AddScoped<IGenMPersonaRepository, GenMPersonaRepository>();
builder.Services.AddScoped<IGenPDocumentoRepository, GenPDocumentoRepository>();
builder.Services.AddScoped<IGenPEpRepository, GenPEpRepository>();
builder.Services.AddScoped<IGePListaopcionRepository, GePListaopcionRepository>();
builder.Services.AddScoped<ILabMOrdenRepository, LabMOrdenRepository>();
builder.Services.AddScoped<ILabMOrdenResultadoRepository, LabMOrdenResultadoRepository>();
builder.Services.AddScoped<ILabPGrupoRepository, LabPGrupoRepository>();
builder.Services.AddScoped<ILabPProcedimientoRepository, LabPProcedimientoRepository>();
builder.Services.AddScoped<ILabPPruebaRepository, LabPPruebaRepository>();
builder.Services.AddScoped<ILabPPruebasOpcionesRepository, LabPPruebasOpcionesRepository>();

builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
        policy.WithOrigins("http://127.0.0.1:7197")
    .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

builder.Services.AddDbContext<SenasoftDbcontext>(options =>
    options.UseMySql(
    connStr,
    ServerVersion.AutoDetect(connStr)
)
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
