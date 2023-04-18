using EmployeeWebAPI.IServices;
using EmployeeWebAPI.Model;
using EmployeeWebAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TestDbContext1>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnString1"));
});

builder.Services.AddDbContext<TestDbContext2>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnString2"));
});

builder.Services.AddDbContext<TestDbContext3>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ConnString3"));
});

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
