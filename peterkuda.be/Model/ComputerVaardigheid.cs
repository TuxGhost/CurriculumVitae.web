using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Model;

public class ComputerVaardigheid
{        
    public string Omschrijving { get; set; } = null!;
    public string Niveau { get; set; } = null!; 
    public string Category { get; set; } = null!;
    public bool AddData{ get; set; } = false;
}
