using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class WerkErvaring
{
    [Key]
    public int Id { get; set; }
    public required string Functie { get; set; } = null!;
    public required string Bedrijf { get; set; } = null!;
    public required DateTime DatumVan { get;set; } 
    public required DateTime DatumTot { get; set; }
    public List<Taak> Taken { get; set; } = null!; 
    public bool Active { get; set; } = false;
}
