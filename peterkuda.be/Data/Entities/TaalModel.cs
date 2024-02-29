using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class TaalModel
{
    [Key]
    public int Id { get; set; }
    public required string Taal { get; set; } = null!;
    public required string Niveau { get; set; } = null!;
    public bool Enabled { get; set; } = true;
}
