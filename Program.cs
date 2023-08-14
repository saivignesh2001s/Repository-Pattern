using Microsoft.EntityFrameworkCore;
using Repository_pattern.context;
using Repository_pattern.Model;
using Repository_pattern.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var string1 = builder.Configuration.GetSection("ConnectionStrings:Default").Value;
builder.Services.AddDbContext<DbClass>(options => options.UseSqlServer(string1.ToString()));
builder.Services.AddTransient<IRepository<user>,Repository<user>>();
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
