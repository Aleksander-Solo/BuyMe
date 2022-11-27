using BuyMe.Application;
using BuyMe.Application.Services;
using BuyMe.Domain.Interfaces.Application;
using BuyMe.Domain.Interfaces.Infrastructure;
using BuyMe.Infrastructure;
using BuyMe.Infrastructure.Repositiores;
using BuyMe.Presentation.JsonConverters;
using BuyMe.Presentation.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
{
    // serialize DateOnly as strings
    x.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    x.JsonSerializerOptions.Converters.Add(new NullableDateOnlyJsonConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<DateOnly>(() => new OpenApiSchema
    {
        Type = "string",
        Format = "date"
    });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BuyMe", Description = "ASP.NET Core Web API.(.Net 6)", Version = "v1" });
});

string? connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddTransient<IBookRepositiory, BookRepositiory>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IFilmRepository, FilmRepository>();
builder.Services.AddTransient<IFilmService, FilmService>();
builder.Services.AddTransient<IGameRepositiory, GameRepositiory>();
builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<MapperConfig>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BuyMe V1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
