using Microsoft.EntityFrameworkCore;
using CurriculumVitaeRepository.Entities;
namespace CurriculumVitaeRepository.Configurations;

public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<JobApplication> builder)
    {
        builder.ToTable("JobApplications");
    }
}
