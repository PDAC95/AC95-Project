using System.ComponentModel.DataAnnotations;

public class ProjectStartFormModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string Phone { get; set; }

    [Required]
    public string ProjectType { get; set; }

    [Required]
    public string Budget { get; set; }

    [Required]
    public string Deadline { get; set; }

    [Required]
    public string Message { get; set; }

    public string HowDidYouHear { get; set; }
}
