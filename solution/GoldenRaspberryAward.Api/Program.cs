using GoldenRaspberryAward.Data.Context;
using GoldenRaspberryAward.Data.Seed;
using GoldenRaspberryAward.Data.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RaspberryAwardContext>(options => options.UseInMemoryDatabase("MovieDB"));
builder.Services.AddScoped<MovieService>();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RaspberryAwardContext>();
    var file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Seed/movieList.csv");
    InitialData.Load(context, file);
}


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

public partial class Program {}