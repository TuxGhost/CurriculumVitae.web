
using CurriculumVitaeRepository.Configurations;
using CurriculumVitaeRepository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CurriculumVitae.Data;
/// <summary>
///     Database context for curriculum vitae data (versie 2)
/// </summary>
public class CVDbContext : DbContext
{
    private IConfiguration _configuration = null!;
    public CVDbContext() { }
    public CVDbContext(DbContextOptions<CVDbContext> options) : base(options) { }    
    public DbSet<Computervaardigheid> ComputerVaardigheden { get; set; } = null!;
    public DbSet<Profiel> Profielen {  get; set; } = null!; 
    public DbSet<Taal> Talen { get; set; } = null!;
    public DbSet<WerkErvaring> WerkErvaringen { get; set; } = null!;
    public DbSet<Persoonlijkevaardigheid> Persoonlijkevaardigheden { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);        
        if (!optionsBuilder.IsConfigured)
        {
            _configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
                 .AddJsonFile("appsettings.json")
                 .Build();
            _ = optionsBuilder.UseSqlite(_configuration.GetConnectionString("Default"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
        modelBuilder.ApplyConfiguration(new ProfielConfiguration());
        modelBuilder.ApplyConfiguration(new ComputervaardigheidConfiguration());
        modelBuilder.ApplyConfiguration(new PersoonlijkevaardigheidConfiguration());
        modelBuilder.ApplyConfiguration(new TaalConfiguration());
        modelBuilder.ApplyConfiguration(new WerkervaringConfiguration());
        modelBuilder.ApplyConfiguration(new TaakConfiguration());
    }
}
