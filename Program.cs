
using GestorViviendaAPI.Data;
using GestorViviendaAPI.Service;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#pragma warning disable CS8604 // Possible null reference argument. 
builder.Services.AddMySQLServer<GestorViviendaContext>(builder.Configuration.GetConnectionString("GestorViviendadb"));
#pragma warning restore CS8604 // Possible null reference argument.

builder.Services.AddScoped<UsuarioService>();

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
