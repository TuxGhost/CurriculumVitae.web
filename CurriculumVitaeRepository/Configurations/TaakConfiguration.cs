using CurriculumVitaeRepository.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurriculumVitaeRepository.Configurations;

public class TaakConfiguration : IEntityTypeConfiguration<Taak>
{
    public void Configure(EntityTypeBuilder<Taak> builder)
    {
        builder.ToTable("Tasks");
    }
}
