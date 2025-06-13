using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Model;

public class WerkErvaring
{    
    public int Id { get; set; }
    public string Functie { get; set; } = null!;
    public string Bedrijf { get; set; } = null!;
    public DateTime DatumVan { get;set; } 
    public DateTime? DatumTot { get; set; }
    public List<string> Taken { get; set; } = null!; 

}
