using CompanySelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySelf.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            var naviagtion = builder.Metadata.FindNavigation(nameof(Company.Employees));
            naviagtion.SetPropertyAccessMode(PropertyAccessMode.Field);
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(d => d.CompanyId);

        }
    }
}
