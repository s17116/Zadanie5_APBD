using Microsoft.EntityFrameworkCore;
using zadanie5;
using zadanie5.Services.Implementations;
using zadanie5.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddDbContext<Context>(opt =>
{
	opt.UseLazyLoadingProxies();
	opt.UseSqlServer(builder.Configuration["ConnectionString"]);
});

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
