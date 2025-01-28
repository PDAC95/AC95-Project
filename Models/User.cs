using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int UserId { get; set; }  // Clave primaria del usuario

    [Required]
    [EmailAddress]
    public string Email { get; set; }  // Correo del usuario

    public string Name { get; set; }  // Nombre del usuario

    // Relación uno a muchos: un usuario puede enviar muchos mensajes
    public ICollection<ContactFormModel> Messages { get; set; }
}
