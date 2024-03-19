using CurriculumVitaeRepository.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CurriculumVitaeRepository.Configurations;

public class PersoonlijkevaardigheidConfiguration : IEntityTypeConfiguration<Persoonlijkevaardigheid>
{
    public void Configure(EntityTypeBuilder<Persoonlijkevaardigheid> builder)
    {
        builder.ToTable("PersonnalSkills");
    }
}
