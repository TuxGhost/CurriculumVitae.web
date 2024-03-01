using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Data.Entities;

public class WerkErvaring
{
    [Key]
    public int Id { get; set; }
    public string Functie { get; set; } = null!;
    public string Bedrijf { get; set; } = null!;
    public DateTime DatumVan { get;set; } 
    public DateTime DatumTot { get; set; }
    public List<Taak> Taken { get; set; } = null!; 

}
