using Microsoft.AspNetCore.Mvc;
using MultiLanguages.Models;
using System.Threading.Tasks;

public class ContactController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly EmailService _emailService;

    public ContactController(ApplicationDbContext context, EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contact(ContactFormModel model)
    {
        if (ModelState.IsValid)
        {
            // Guardar los datos en la base de datos
            _context.ContactForms.Add(model);
            await _context.SaveChangesAsync();

            // Asunto y mensaje del correo
            var subject = "Nuevo mensaje de contacto de " + model.Name;
            var message = $"<p>Nombre: {model.Name}</p><p>Email: {model.Email}</p><p>Mensaje: {model.Message}</p>";

            // Enviar el correo a admin@ac95.ca
            await _emailService.SendEmailAsync("hello@ac95.ca", subject, message);

            // Redirigir a la página de confirmación
            return RedirectToAction("Confirmation", "Home");
        }

        // Si hay errores en el modelo, recargar la vista con los datos del formulario
        return View(model);
    }


    public IActionResult Confirmation()
    {
        return View();
    }
}
