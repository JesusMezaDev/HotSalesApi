using MediatR;

using HotSalesCore.Data;
using HotSalesCore.Features.ApiResponse.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

var stringConnection = builder.Configuration.GetConnectionString("MSSQL");
services.AddSingleton(new SqlConnectionFactory(stringConnection));

services.AddMediatR(typeof(ApiResponseModel));

services.AddCors(options =>
{
    options.AddPolicy(name: "HotSalesApi", builder => {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

// Add services to the container.

services.AddControllers()
    .AddJsonOptions(item => item.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

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

app.UseCors("HotSalesApi");

app.Run();
