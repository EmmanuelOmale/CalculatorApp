using CalculatorApp.Infrastructure.Data;
using CalculatorApp.Infrastructure.Repository;
using CalculatorApp.Infrastructure.Repository.Interfaces;
using CalculatorApp.Services;
using CalculatorApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();
builder.Services.AddScoped<ICalculatorRepository, CalculatorRepository>();
builder.Services.AddCors(
    option =>
    {
        option.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyHeader();
            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        });

    });

builder.Services.AddDbContext<CalculatorContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));
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
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
