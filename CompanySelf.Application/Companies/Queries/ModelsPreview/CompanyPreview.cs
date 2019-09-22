using CompanySelf.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CompanySelf.Application.Companies.Queries.ModelsPreview
{
    public class CompanyPreview
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<EmployeePreview> Employees { get; set; }

        public static Expression<Func<Company, CompanyPreview>> Projection
        {
            get
            {
                return c => new CompanyPreview
                {
                    Name = c.Name,
                    EstablishmentYear = c.EstablishmentYear,
                    Employees = c.Employees.AsQueryable().Select(EmployeePreview.Projection).ToList()
                };
            }
        }
    }
}