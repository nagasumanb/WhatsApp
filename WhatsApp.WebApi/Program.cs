using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WhatsApp.Entity.data;
using WhatsApp.Entity.Models;
using WhatsApp.Services.Dtos.Account;
using WhatsApp.Services.Repositorys.Account;
using WhatsApp.Services.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WhatsAppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<RegisterUsers, IdentityRole>()
    .AddEntityFrameworkStores<WhatsAppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IValidator<RegisterUserRequestDto>, RegisterUserRequestDtoValidator>();


builder.Services.AddScoped<IAccountRepository, AccountRepository>();

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
