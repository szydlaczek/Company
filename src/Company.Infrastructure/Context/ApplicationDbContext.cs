using CompanySelf.Core.Models;
using System.Data.Entity;

namespace CompanySelf.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("Company")
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}