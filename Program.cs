using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using MultiLanguages.Models;  // Cambia "MultiLanguages" por el namespace correcto

var builder = WebApplication.CreateBuilder(args);

// 🔹 1. Agregar el servicio de Entity Framework Core con la cadena de conexión
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 🔹 2. Agregar servicios de localización
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// 🔹 3. Habilitar la localización de vistas
builder.Services.AddMvc().AddViewLocalization();

// 🔹 4. Configurar localización con cookies
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("es")
    };

    options.DefaultRequestCulture = new RequestCulture("en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
});

// 🔹 5. Agregar servicios al contenedor
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EmailService>();

var app = builder.Build();

// 🔹 6. Aplicar la configuración de localización
var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);

// 🔹 7. Configurar el pipeline de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
// 🔁 Redireccionar sin www a www
app.Use(async (context, next) =>
{
    var host = context.Request.Host.Host;
    if (host == "ac95.ca")
    {
        var newHost = new HostString("www.ac95.ca");
        var newUrl = $"{context.Request.Scheme}://{newHost}{context.Request.Path}{context.Request.QueryString}";
        context.Response.Redirect(newUrl, permanent: true);
        return;
    }
    await next();
});

app.UseRouting();
app.UseAuthorization();

// 🔹 8. Configurar las rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
