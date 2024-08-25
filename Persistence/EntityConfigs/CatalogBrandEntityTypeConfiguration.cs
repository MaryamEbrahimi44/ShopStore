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
    public class CatalogBrandEntityTypeConfiguration : IEntityTypeConfiguration<CatalogBrand>
    {
         void IEntityTypeConfiguration<CatalogBrand>.Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");
            builder.Property(cb => cb.Brand)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
