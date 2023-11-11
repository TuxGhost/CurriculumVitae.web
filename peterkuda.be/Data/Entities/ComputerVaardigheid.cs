using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class ComputerVaardigheid
{
    [Key]
    public int Id { get; set; }
    public string Omschrijving { get; set; } = null!;
    public string Niveau { get; set; } = null!; 
    public string Category { get; set; } = null!;
}
