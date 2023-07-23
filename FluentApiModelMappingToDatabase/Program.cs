using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
//var strcon = Environment.GetEnvironmentVariable("DB_CONNECTION");
builder.Services.AddDbContext<AppDbContext>(options =>
{
  //  options.UseSqlServer(strcon);
   options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

//    // Set the Swagger base URL based on the environment
//    string baseUrl = builder.Environment.IsDevelopment()
//        ? "http://localhost:80"  // Development environment (when running locally)
//        : "http://localhost:6314"; // Docker container or production environment
//    c.AddServer(new OpenApiServer { Url = baseUrl });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    //})
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
