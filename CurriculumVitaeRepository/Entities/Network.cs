using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurriculumVitaeRepository.Entities;

public class Network
{
    [Key]
    public uint Id { get; set; }
    public uint ProfielId { get; set; }
    [ForeignKey(nameof(ProfielId))]
    public required Profiel Profiel { get; set; }
    public required string Name { get; set; }  = string.Empty;
    public required string Lastname { get; set; }
    public string Function { get; set; } = string.Empty;
    public string Company {  get; set; } = string.Empty;
    public string NetworkType {  get; set; } = string.Empty;
}
