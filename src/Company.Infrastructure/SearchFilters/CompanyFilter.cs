using CompanySelf.Core.Models;
using CompanySelf.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanySelf.Infrastructure.SearchFilters
{
    public static class CompanyFilter
    {
        public static IQueryable<Company> Filter(this IQueryable<Company> query, SearchCriteria criteria)
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
                HashSet<JobTitle> Jobs = new HashSet<JobTitle>();
                foreach (var jobTitle in criteria.EmployeeJobTitles.Distinct())
                {
                    try
                    {
                        Jobs.Add((JobTitle)Enum.Parse(typeof(JobTitle), jobTitle));
                    }
                    catch
                    {
                        Jobs.Add(JobTitle.None);
                    }
                }
                query = query.Where(e => e.Employees.Any(d => Jobs.Contains(d.JobTitle)));
            }
            return query;
        }
    }
}