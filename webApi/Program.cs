using BLL;
using Microsoft.OpenApi.Models;
using AutoMapper;
using BLL.BllModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<BlManager>();

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactCorsPolicy",
        builder => builder.WithOrigins("https://search.foirstein.diversitech.co.il")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
// Use CORS policy
app.UseCors("ReactCorsPolicy");

app.MapControllers();

app.MapGet("/", () => "Welcome!!!");

app.Run();
