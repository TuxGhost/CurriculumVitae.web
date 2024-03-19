using System.ComponentModel.DataAnnotations;

namespace CurriculumVitaeRepository.Entities;

public class Persoonlijkevaardigheid
{
    [Key]
    public uint Id { get; set; }
    public required Profiel profiel { get; set; }    
    public required string Name { get; set; }  
    public required bool Enabled { get; set; }
}
