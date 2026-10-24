using MinhaApi.Repositories;
using MinhaApi.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(options => {
    options.AddPolicy("FrontendPolic", policy => {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// ✅ Registra o Repository
builder.Services.AddScoped<
    IProdutoRepository,
    ProdutoRepository>();

// ✅ Registra a Service
builder.Services.AddScoped<
    IProdutoService,
    ProdutoService>();

    // ✅ Registra o Repository
builder.Services.AddScoped<
    IClienteRepository,
    ClienteRepository>();

// ✅ Registra a Service
builder.Services.AddScoped<
    IClienteService,
    ClienteService>();
// ✅ Registra o Repository
builder.Services.AddScoped<
    IVendaRepository,
    VendaRepository>();
//Registro do repository
    builder.Services.AddScoped<
    IVendaService,
    VendaService>();
    // ✅ Registra o Repository
    builder.Services.AddScoped<
    IFornecedorRepository,
    FornecedorRepository>();
// ✅ Registra a Service
    builder.Services.AddScoped<
    IFornecedorService,
    FornecedorService>();
    // ✅ Registra a Service
    builder.Services.AddScoped<
    DepartamentoService,
    DepartamentoService>();
    // ✅ Registra o Repository
    builder.Services.AddScoped<
    IDepartamentoRepository,
    DepartamentoRepository>();

    
// ===== JWT (antes do builder.Build()) =====
var jwtKey = builder.Configuration["Jwt:Key"]!;

builder.Services
  .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(opt => {
    opt.TokenValidationParameters = new TokenValidationParameters {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(jwtKey)),
      ValidateIssuer   = true,
      ValidIssuer      = builder.Configuration["Jwt:Issuer"],
      ValidateAudience = true,
      ValidAudience    = builder.Configuration["Jwt:Audience"],
      ValidateLifetime = true
    };
  });

// ===== Injeção de Dependência =====
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// ===== Pipeline — A ORDEM IMPORTA =====
app.UseCors(/* sua política */);
app.UseAuthentication();  // 1º quem é você?
app.UseAuthorization();   // 2º você pode entrar?
app.MapControllers();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // Controllers

}
    app.UseCors("FrontendPolic");
    app.MapControllers();
    // Inicia a API

    app.Run();

    