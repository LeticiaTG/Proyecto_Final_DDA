using Microsoft.EntityFrameworkCore;
using Proyecto_Final_DDA.Servicios.Contrato;
using Proyecto_Final_DDA.Servicios.Implementacion;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//////(Controlador del Login) Parte agregada por Leticia 
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        //Esta parte aqui es el tiempo de Expiracion del Usuario en la Sesion
        options.LoginPath = "/Inicio/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);   


    });
///// Fin Controlador del Login

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

//Login Autenticacion
app.UseAuthentication();    

app.UseAuthorization();

//Pagina en la que iniciara el proyecto(en el login)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");

app.Run();
