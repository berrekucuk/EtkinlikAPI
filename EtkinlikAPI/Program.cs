using EtkinlikAPI.Models.ORM;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using EtkinlikAPI.Models.Validations;
using EtkinlikAPI.Models.DTO;
using EtkinlikAPI.Models.Validations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//SQL baðlantýsý için gerekli olan kod.
builder.Services.AddDbContext<EventContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Bankend'i Frontend'e baðlamak için kullanýlan kod.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateCategoryRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateActivityRequestValidator>();

//JWT kullanýmý için gereken kodlar.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "berre@mail.com",
        ValidAudience = "berre1@mail.com",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ironmaidenpentagramslipknotironmaidenpentagramslipknot")),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//JWT kullanýmý için gereken kodlar.
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//Ön yüzde resimleri göstememiz için bu kodu yazmamýz gerek.
app.UseStaticFiles();

app.UseCors();

app.Run();
