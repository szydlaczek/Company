using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanySelf.Core.Models
{
    public class Employee : Entity<long>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public JobTitle JobTitle { get; set; }

        [ForeignKey("Company")]
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }
        //public virtual Company Company { get; private set; }

        public Employee()
        {
        }
    }
}