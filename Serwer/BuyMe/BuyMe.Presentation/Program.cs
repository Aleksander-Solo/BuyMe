using BuyMe.Application;
using BuyMe.Application.Services;
using BuyMe.Domain.Interfaces.Application;
using BuyMe.Domain.Interfaces.Infrastructure;
using BuyMe.Infrastructure;
using BuyMe.Infrastructure.Repositiores;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string? connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddTransient<IBookRepositiore, BookRepositiore>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<MapperConfig>();

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
