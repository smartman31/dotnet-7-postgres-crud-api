namespace WebApi.Entities;

public class Tutorial
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public bool? Published { get; set; }
}