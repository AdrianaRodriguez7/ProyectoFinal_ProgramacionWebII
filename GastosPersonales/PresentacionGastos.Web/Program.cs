using Microsoft.EntityFrameworkCore;
using DatosGastos.Data;
using EnlaceGastos.Services.Interfaces;
using EnlaceGastos.Services.Servicios;
using EnlaceGastos.Services.Estrategias;


var builder = WebApplication.CreateBuilder(args);

// Agregar el DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));

// Agregar servicios personalizados
builder.Services.AddScoped<ITransaccionService, TransaccionService>();
builder.Services.AddScoped<IResumenService, ResumenService>();
builder.Services.AddScoped<IAnalisisFinancieroStrategy, EstrategiaMensaje>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

// REGISTRO DE SERVICIOS PERSONALIZADOS
builder.Services.AddScoped<ITransaccionService, TransaccionService>();
builder.Services.AddScoped<IResumenService, ResumenService>();
builder.Services.AddScoped<IAnalisisFinancieroStrategy, EstrategiaMensaje>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
