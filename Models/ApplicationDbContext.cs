using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MultiLanguages.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para los usuarios
        public DbSet<User> Users { get; set; }  // Esta es la tabla de usuarios

        // DbSet para los mensajes de contacto
        public DbSet<ContactFormModel> ContactForms { get; set; }  // Esta es la tabla de mensajes

        // DbSet para los mensajes de un nuevo proyecto
        public DbSet<ProjectStartFormModel> ProjectStartForms { get; set; }
    }
}

