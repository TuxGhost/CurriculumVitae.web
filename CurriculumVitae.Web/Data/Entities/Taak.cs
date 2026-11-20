using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class Taak
{
    public uint Id { get; set; }
    [Required]
    public  string Bechrijving { get; set; } = null!;
    public bool Enabled { get; set; } = true;
}
