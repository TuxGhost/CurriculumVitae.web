using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class Taak
{
    public uint Id { get; set; }
    [Required]
    public required string Bechrijving { get; set; } = null!;
}
