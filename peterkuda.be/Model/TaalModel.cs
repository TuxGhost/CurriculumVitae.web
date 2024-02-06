using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Model;

public class TaalModel
{
    public string Taal { get; set; } = null!;
    public string Niveau { get; set; } = null!;
    public bool AddData { get; set; } = false;
}
