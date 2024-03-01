using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class Profiel
{
    [Key]
    public uint Id { get; set; }
    [Required]
    public string Beschrijving { get; set; } = null!;
    public bool Enabled { get; set; } = true;
}
