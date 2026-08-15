using CurriculumVitaeRepository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurriculumVitaeRepository.Configurations;

public class NetworkConfiguration : IEntityTypeConfiguration<Network>
{
    public void Configure(EntityTypeBuilder<Network> builder)
    {
        builder.ToTable("Network");
    }
}
