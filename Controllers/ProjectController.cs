using Microsoft.AspNetCore.Mvc;
using MultiLanguages.Models;
using System.Threading.Tasks;

public class ProjectController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly EmailService _emailService;

    public ProjectController(ApplicationDbContext context, EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    [HttpGet]
    public IActionResult StartProject()
    {
        return View("stated"); // Llama a la vista "stated" en la carpeta "Home"
    }

    [HttpPost]
    public async Task<IActionResult> StartProject(ProjectStartFormModel model)
    {
        if (ModelState.IsValid)
        {
            // Guardar en la base de datos
            _context.ProjectStartForms.Add(model);
            await _context.SaveChangesAsync();

            // Enviar el correo
            var subject = $"New Project Submission from {model.Name}";
            var message = $@"
                <p><strong>Name:</strong> {model.Name}</p>
                <p><strong>Email:</strong> {model.Email}</p>
                <p><strong>Phone:</strong> {model.Phone}</p>
                <p><strong>Project Type:</strong> {model.ProjectType}</p>
                <p><strong>Budget:</strong> {model.Budget}</p>
                <p><strong>Deadline:</strong> {model.Deadline}</p>
                <p><strong>Message:</strong> {model.Message}</p>
                <p><strong>How Did You Hear:</strong> {model.HowDidYouHear}</p>
            ";

            await _emailService.SendEmailAsync("admin@ac95.ca", subject, message);

            return RedirectToAction("Confirmation", "Home");
        }

        // Si hay errores, devolver al formulario
        return View("stated", model);
    }
}
