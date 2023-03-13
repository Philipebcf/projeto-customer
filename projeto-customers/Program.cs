using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using projeto_customers.Data;
using projeto_customers.Models;
using projeto_customers.Operations;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//configurando contexto de banco de dados
builder.Services.AddDbContext<DbCustomerContext>
    (opt => opt.UseMySQL(builder.Configuration.GetConnectionString("ConnectionDbCustomer")));

builder.Services.AddScoped<CustomerOperations, CustomerOperations>();
builder.Services.AddScoped<Customer, Customer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
