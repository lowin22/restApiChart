using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TaskOne.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskOneLenguageContext>(otp => otp.UseSqlServer(builder.Configuration.GetConnectionString("conectionSql")));

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var myRulesCors = "ReglasCors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: myRulesCors, builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(myRulesCors);
app.UseAuthorization();

app.MapControllers();

app.Run();
