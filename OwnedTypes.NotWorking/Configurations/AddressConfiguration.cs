using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnedTypes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(prop => prop.AddressId);

            builder.Property(prop => prop.Line1)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(prop => prop.Line2)
                .IsRequired(false)
                .HasMaxLength(50);
        }
    }
}
