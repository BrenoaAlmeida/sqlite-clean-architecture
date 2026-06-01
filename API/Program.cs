using Application;
using Application.Interfaces;
using Domain;
using Repository;
using Repository.Interfaces;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddModelConfiguration(builder.Configuration);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICarroRepository, CarroRepository>();
builder.Services.AddScoped<ICarroService, CarroService>();
builder.Services.AddOpenApi();

var app = builder.Build();

// ==========================================
// 2. CONFIGURAR O PIPELINE DE REQUISIÇÕES (Middlewares)
// ==========================================
if (app.Environment.IsDevelopment())
{
    // Gera o endpoint do arquivo JSON (ex: /openapi/v1.json)
    app.MapOpenApi();        

    app.MapScalarApiReference(options =>
    {
        options.WithTitle("API de teste SQLITE")
        .WithTheme(ScalarTheme.Moon);
    });


}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
