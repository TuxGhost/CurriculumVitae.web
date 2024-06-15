using System.ComponentModel.DataAnnotations;

namespace CurriculumVitaeRepository.Entities;
public class Profiel
{
    [Key]
    public uint Id { get; set; }    
    public required string Beschrijving { get; set; }
    public bool Enabled { get; set; } = true;
}
