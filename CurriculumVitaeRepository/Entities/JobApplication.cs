using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurriculumVitaeRepository.Entities;

public class JobApplication
{
    [Key]
    public uint Id { get; set; }
    public uint ProfielId { get; set; }
    [ForeignKey(nameof(ProfielId))]
    public required Profiel Profiel { get; set; }
    public string Function {  get; set; } = string.Empty;
    public DateOnly ApplicationDate { get; set; }
    public string Description { get; set; } = string.Empty;
}
 