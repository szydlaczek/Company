using System;

namespace CompanySelf.Domain.Entities
{
    public class Employee : Entity<long>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public JobType Job { get; set; }

        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }
        //public virtual Company Company { get; private set; }

        public Employee()
        {
        }
    }
}