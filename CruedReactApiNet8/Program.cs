using CruedReactApiNet8.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Bd conection
builder.Services.AddDbContext<DbacrudReactnetapi8Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Cors Any connection
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolReact", app =>
    {
        //app.AllowAnyOrigin().AllowAnyMethod();
        app.WithOrigins("http://localhost:5173").AllowAnyHeader().AllowAnyMethod();

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolReact");
app.UseAuthorization();
app.MapControllers();

app.Run();
