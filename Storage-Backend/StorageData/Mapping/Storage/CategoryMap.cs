using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StorageEntities.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageData.Mapping.Storage
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category")
                .HasKey(c => c.idcategory);
            builder.Property(c => c.name)
                .HasMaxLength(50);
            builder.Property(c => c.description)
                .HasMaxLength(256);
        }
    }
}
