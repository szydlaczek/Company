using CompanySelf.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace CompanySelf.Application.Companies.Queries.ModelsPreview
{
    public class EmployeePreview
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string JobTitle { get; set; }

        public static Expression<Func<Employee, EmployeePreview>> Projection
        {
            get
            {
                return e => new EmployeePreview
                {
                    DateOfBirth = e.DateOfBirth.ToString("yyyy-MM-dd"),
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.Job.ToString()
                };
            }
        }
    }
}