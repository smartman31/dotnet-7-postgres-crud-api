namespace WebApi.Models.Tutorials;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UpdateTutorialRequest
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? Published { get; set; }
}