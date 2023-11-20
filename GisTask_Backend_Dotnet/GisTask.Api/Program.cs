using GisTask.Application.Interfaces;
using GisTask.Application.Services;
using Microsoft.EntityFrameworkCore;
using AppContext = GisTask.Domain.AppContext;

var builder = WebApplication.CreateBuilder(args);

var cors = builder.Configuration["CorsOrigin"];

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(
        policy =>
            policy.WithOrigins(builder.Configuration["CorsOrigin"])
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials()
        )
    );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration["DbConnectionString"];

builder.Services.AddDbContext<AppContext>(opt => opt.UseSqlServer(builder.Configuration["DbConnectionString"]));
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<ICalculationsService, CalculationsService>();

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
