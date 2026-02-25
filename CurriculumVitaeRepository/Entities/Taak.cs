using System.ComponentModel.DataAnnotations;

namespace CurriculumVitaeRepository.Entities;

public class Taak
{
    public uint Id { get; set; }
    public required WerkErvaring WerkErvaring { get;set; }
    public required string Beschrijving { get; set; } = null!;
}
