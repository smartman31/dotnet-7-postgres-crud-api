namespace WebApi.Models.Tutorials;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateTutorialRequest
{
    [Required]
    public string? Title { get; set; }

    [Required]
    public string? Description { get; set; }

    public bool? Published { get; set; }
}