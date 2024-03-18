using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class PersoonlijkeVaardigheid
{
    [Key]
    public uint Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public bool Enabled { get; set; } = true;
}
