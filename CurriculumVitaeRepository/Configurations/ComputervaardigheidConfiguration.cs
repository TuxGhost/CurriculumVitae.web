using CurriculumVitaeRepository.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurriculumVitaeRepository.Configurations;

public class ComputervaardigheidConfiguration : IEntityTypeConfiguration<Computervaardigheid>
{
    public void Configure(EntityTypeBuilder<Computervaardigheid> builder)
    {
        builder.ToTable("ComputerSkills");
    }
}
