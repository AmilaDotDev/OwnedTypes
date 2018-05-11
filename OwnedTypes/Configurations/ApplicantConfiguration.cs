using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnedTypes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes.Configurations
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.HasKey(prop => prop.ApplicantId);

            builder.OwnsOne(prop => prop.Name, name =>
            {
                name
                .OwnsOne(prop => prop.FirstName)
                .Property("_value")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("FirstName");

                name
                .OwnsOne(prop => prop.LastName)
                .Property("_value")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("LastName");
            });
        }
    }
}
