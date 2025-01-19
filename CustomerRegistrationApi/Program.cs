using CustomerRegistrationApi.Mapping;
using CustomerRegistrationApi.Repositories;
using CustomerRegistrationApi.Repositories.Interfaces;
using CustomerRegistrationApi.Services;
using CustomerRegistrationApi.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var secretKey = builder.Configuration["secretkey"] ?? string.Empty;
var chaveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["ValidIssuer"] ?? string.Empty,
            ValidAudience = builder.Configuration["ValidAudience"] ?? string.Empty,
            IssuerSigningKey = chaveSimetrica
        };
    });

builder.Services.AddAuthorization();


// Adicionar AutoMapper ao contêiner de dependências
builder.Services.AddAutoMapper(typeof(CustomerProfile)); // Adicionando o Profile de Mapeamento
// Add services to the container.

// Configura o DbContext com SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerService>();
// Registra o repositório com a injeção de dependência para memoria
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
// Registra o repositório com a injeção de dependência para sqlserver
//builder.Services.AddScoped<ICustomerRepository, SqlServerCustomerRepository>();


var app = builder.Build();
app.UseAuthentication(); // Habilita a autenticação
app.UseAuthorization();  // Habilita a autorização

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
