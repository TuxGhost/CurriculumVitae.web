using CurriculumVitaeRepository.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurriculumVitaeRepository.Configurations;

public class TaalConfiguration : IEntityTypeConfiguration<Taal>
{
    public void Configure(EntityTypeBuilder<Taal> builder)
    {
        builder.ToTable("Languages");
    }
}
