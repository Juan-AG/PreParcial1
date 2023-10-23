using Microsoft.EntityFrameworkCore;
using PreParcial.DAL;
using PreParcial.Domain.Interfaces;
using PreParcial.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Esta línea me crea el contexto de la BD a la hora de correr esta API
//Funciones Anónimas (x => x....) Arrow Functions - Lambda Functions
builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICountryService, StateService>();
//Por cada nuevo servicio/interfaz que yo creo en mi API, debo agregar aquí esa nueva dependencia 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
