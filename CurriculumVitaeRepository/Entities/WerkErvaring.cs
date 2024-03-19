using System.ComponentModel.DataAnnotations;

namespace CurriculumVitaeRepository.Entities;

public class WerkErvaring
{
    [Key]
    public int Id { get; set; }
    public required Profiel profiel { get; set; }
    public required string Functie { get; set; } 
    public required string Bedrijf { get; set; } 
    public required DateTime DatumVan { get;set; } 
    public DateTime DatumTot { get; set; }
    public List<Taak> Taken { get; set; } = null!; 

}
