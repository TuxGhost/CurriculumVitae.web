using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Model;

public class CvModel
{   public bool Editable {get; set; } = false;     
    public string? Profiel { get; set; }
    public List<string> Lijnen { get; set; }  = new List<string>();
    public List<TaalModel> Talen { get; set; } = new List<TaalModel>();
    public List<string> PersoonlijkeVaardigheden { get; set; } = new List<string> ();
    public List<ComputerVaardigheid> ComputerVaardigheden { get; set; } = new List<ComputerVaardigheid>();
    public List<WerkErvaring> WerkErvaringen { get; set; } = new List<WerkErvaring>();
}
