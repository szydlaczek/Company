using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanySelf.Core.Models
{
    public class Company : Entity<long>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int EstablishmentYear { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public Company()
        {
            Employees = new HashSet<Employee>();
        }
    }
}