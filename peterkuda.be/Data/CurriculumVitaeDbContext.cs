using CurriculumVitae.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurriculumVitae.Data;

public class CurriculumVitaeDbContext : DbContext
{
    public CurriculumVitaeDbContext(DbContextOptions<CurriculumVitaeDbContext> options) : base(options) { }

    public DbSet<ComputerVaardigheid> computerVaardigheiden { get; set; } = null!;
    public DbSet<Profiel> Profielen {  get; set; } = null!; 
    public DbSet<TaalModel> Talen { get; set; } = null!;
    public DbSet<WerkErvaring> WerkErvaringen { get; set; } = null!;    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
