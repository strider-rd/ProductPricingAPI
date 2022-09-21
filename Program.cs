using ConfigureContainers;
using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Dependancy Injection
builder.Services.ConfigureContainers();

builder.Services.AddDbContext<RepositoryContext>(opt => opt.UseInMemoryDatabase("TravelUp"), 
                            optionsLifetime: ServiceLifetime.Singleton);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

DataGenerator.InitData(app.Services);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();
