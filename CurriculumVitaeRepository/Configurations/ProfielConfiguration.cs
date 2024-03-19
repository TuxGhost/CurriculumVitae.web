using CurriculumVitaeRepository.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurriculumVitaeRepository.Configurations;

public class ProfielConfiguration : IEntityTypeConfiguration<Profiel>
{
    public void Configure(EntityTypeBuilder<Profiel> builder)
    {
        builder.ToTable("Profiles");
    }
}
