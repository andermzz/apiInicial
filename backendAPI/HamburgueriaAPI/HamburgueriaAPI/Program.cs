using HamburgueriaAPI.Models;
using HamburgueriaAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BdHamburgueriaContext>(o =>
o.UseSqlServer(builder.Configuration.GetConnectionString("conexao")));
/*
builder.Services.AddCors(options => {
    options.AddPolicy(name: "acessogeral",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173/", "https://localhost:7106/").AllowAnyHeader().AllowAnyMethod();
        });
    }
);*/


builder.Services.AddCors(options =>
{
    options.AddPolicy("acessogeral",
        builder => builder.WithOrigins("http://localhost:5173") // URL da origem permitida
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("acessogeral");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
