using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class PersoonlijkeVaardigheid
{
    [Key]
    public uint Id { get; set; }
    [Required]
    public string Name { get; set; }
}
