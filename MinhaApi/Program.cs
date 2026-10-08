using MinhaApi.Repositories;
using MinhaApi.Services;

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

var app = builder.Build();

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