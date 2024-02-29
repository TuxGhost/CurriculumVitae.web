using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class TaalModel
{
    [Key]
    public int Id { get; set; }
    public string Taal { get; set; } = null!;
    public string Niveau { get; set; } = null!;
}
