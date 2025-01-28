using System.ComponentModel.DataAnnotations;

public class ContactFormModel
{
    [Key]
    public int Id { get; set; }  // Clave primaria del mensaje

    [Required]
    [StringLength(100)]
    public string Name { get; set; }  // Nombre del remitente

    [Required]
    [EmailAddress]
    public string Email { get; set; }  // Email del remitente

    [Required]
    [StringLength(1000)]
    public string Message { get; set; }  // El mensaje
}
