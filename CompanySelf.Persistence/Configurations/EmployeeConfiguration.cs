using CompanySelf.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySelf.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(o => o.Company)
                .WithMany(m => m.Employees)
                .HasForeignKey(f => f.CompanyId);

        }
    }
}
