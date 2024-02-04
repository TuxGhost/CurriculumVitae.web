using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class ComputerVaardigheid
{
    [Key]
    public int Id { get; set; }
    public required string Omschrijving { get; set; } = null!;
    public required string Niveau { get; set; } = null!; 
    public required string Category { get; set; } = null!;
}
