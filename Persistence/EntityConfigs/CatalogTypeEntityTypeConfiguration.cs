using Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigs
{
    public class CatalogTypeEntityTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        void IEntityTypeConfiguration<CatalogType>.Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");
            builder.Property(cb => cb.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
