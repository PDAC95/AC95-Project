using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MultiLanguages.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult SetLanguage(string culture)
        {
            // Guardar el idioma en una cookie
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            // Redirigir a la página Home (no Index) después de cambiar el idioma
            return RedirectToAction("Home", "Home");
        }
    }
}

