using CurriculumVitaeRepository.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurriculumVitaeRepository.Configurations;

public class WerkervaringConfiguration : IEntityTypeConfiguration<WerkErvaring>
{
    public void Configure(EntityTypeBuilder<WerkErvaring> builder)
    {
        builder.ToTable("Workexperiences");
    }
}
