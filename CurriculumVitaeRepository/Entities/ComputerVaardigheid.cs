using System.ComponentModel.DataAnnotations;

namespace CurriculumVitaeRepository.Entities;

public class Computervaardigheid
{
    [Key]
    public int Id { get; set; }
    public required Profiel Profiel { get; set; }
    public required string Omschrijving { get; set; } 
    public required string Niveau { get; set; } 
    public required string Category { get; set; } 
}
