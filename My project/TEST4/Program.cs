using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TestWebapi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string conStr1 = "server=localhost;port=3306;uid=root;pwd=sds2234272755;database=school";
builder.Services.AddDbContext<DatabaseContext>(opt => {
    /*string connectionString = builder.Configuration.GetConnectionString("MySQLConnection");*/
    var serverVersion = ServerVersion.AutoDetect(conStr1);
    opt.UseMySql(conStr1, serverVersion);
});

builder.Services.AddCors(c=>c.AddPolicy("any",p=>p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
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

app.UseCors();

app.MapControllers();

app.Run();
