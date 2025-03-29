using Inventory.Api.Data;
using Inventory.Api.Repositories.Implementations;
using Inventory.Api.Repositories.Interfaces;
using Inventory.Api.UnitsOfWork.Implementations;
using Inventory.Api.UnitsOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("dbConn")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IUnitOfWork<>), typeof(GenericUnitOfWork<>));

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