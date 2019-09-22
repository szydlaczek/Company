using System;
using System.Collections.Generic;

namespace CompanySelf.Domain.Entities
{
    public class Company : Entity<long>
    {
        public string Name { get; protected set; }

        public int EstablishmentYear { get; protected set; }

        private List<Employee> _employees;
        public IReadOnlyCollection<Employee> Employees => _employees;

        protected Company()
        {
            _employees = new List<Employee>();
        }

        public Company(string name, int establismentYear):this()
        {
            Name = name;
            EstablishmentYear = establismentYear;
        }

        public void AddEmployee(string firstName, string lastName, DateTime dateOfBirth, JobType job)
        {
            var employee = new Employee
            {
                DateOfBirth = dateOfBirth,
                FirstName = firstName,
                LastName = lastName,
                Job = job
            };

            _employees.Add(employee);
        }

        public void UpdateCompany(string name, int establishmentYear)
        {
            Name = name;
            EstablishmentYear = establishmentYear;
        }

    }
}