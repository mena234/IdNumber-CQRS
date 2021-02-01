using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdNuber.Infrastructure.EntityConfigurations
{
    public class IdNumberEntityTypeConfiguration : IEntityTypeConfiguration<IdNumber>
    {
        public void Configure(EntityTypeBuilder<IdNumber> builder)
        {
            builder.ToTable("IdNumber", IdNumberContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);
            builder.Property<int>("BuildingCode").IsRequired(false);
            builder.Property<string>("BuildingType").IsRequired(false);
            builder.Property<string>("Conservativecode").IsRequired(false);
        }

    }
}
