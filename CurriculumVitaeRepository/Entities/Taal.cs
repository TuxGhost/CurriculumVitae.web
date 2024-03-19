using System.ComponentModel.DataAnnotations;

namespace CurriculumVitaeRepository.Entities;

public class Taal
{
    [Key]
    public int Id { get; set; }
    public required Profiel profiel { get; set; }
    public required string TaalOmschrijving { get; set; } 
    public required string Niveau { get; set; } 
}
