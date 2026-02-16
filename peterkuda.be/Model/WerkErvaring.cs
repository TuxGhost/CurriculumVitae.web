using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Model;

public class WerkErvaring
{   
    private int _dagen;
    public int Id { get; set; }
    public string Functie { get; set; } = null!;
    public string Bedrijf { get; set; } = null!;
    public DateTime DatumVan { get;set; } 
    public DateTime? DatumTot { get; set; }
    public List<string> Taken { get; set; } = null!; 
    public int getDagen()
    {
        int dagen = 0;
        if (DatumTot == null)
        {
            dagen =  (int)(DateTime.Now - DatumVan).TotalDays;
        }
        else
        {
            dagen =  (int)(DatumTot.Value - DatumVan).TotalDays;
        }
        //dagen = dagen  / 7 * 5; // Assuming 5 working days per week
        return dagen;
    }

}
