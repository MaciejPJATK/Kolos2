using Kolos2.DAL;
using Kolos2.Services;
using Kolos2.Middlewares; // <= DODAJ!
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Concert Ticket Kolos2 API",
        Version = "v1"
    });
});

builder.Services.AddDbContext<GalleryDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IGalleryService, GalleryService>();

var app = builder.Build();

app.UseGlobalExceptionHandling(); // <= TUTAJ

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();