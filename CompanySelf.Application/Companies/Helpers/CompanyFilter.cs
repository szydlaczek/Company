using CompanySelf.Application.Companies.Queries.SearchCompany;
using CompanySelf.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanySelf.Application.Companies.Helpers
{
    public static class CompanyFilter
    {
        public static IQueryable<Company> Filter(this IQueryable<Company> query, SearchCompanyQuery criteria)
        {
            if (!string.IsNullOrEmpty(criteria.Keyword))
            {
                query = query
                    .Where(c => c.Name.Contains(criteria.Keyword) || c.Employees.Any(e => e.FirstName.Contains(criteria.Keyword) || e.LastName.Contains(criteria.Keyword)));
            }

            if (criteria.EmployeeDateOfBirthFrom != null)
            {
                var EmployeeDateOfBirthFrom = Convert.ToDateTime(criteria.EmployeeDateOfBirthFrom);
                query = query.Where(e => e.Employees.Any(d => d.DateOfBirth > EmployeeDateOfBirthFrom));
            }

            if (criteria.EmployeeDateOfBirthTo != null)
            {
                var EmployeeDateOfBirthTo = Convert.ToDateTime(criteria.EmployeeDateOfBirthTo);
                query = query.Where(e => e.Employees.Any(d => d.DateOfBirth < EmployeeDateOfBirthTo));
            }

            if (criteria.EmployeeJobTitles.Count() > 0)
            {
                HashSet<JobType> Jobs = new HashSet<JobType>();
                foreach (var jobTitle in criteria.EmployeeJobTitles.Distinct())
                {
                    try
                    {
                        Jobs.Add((JobType)Enum.Parse(typeof(JobType), jobTitle));
                    }
                    catch
                    {
                        Jobs.Add(JobType.None);
                    }
                }
                query = query.Where(e => e.Employees.Any(d => Jobs.Contains(d.Job)));
            }
            return query;
        }
    }
}