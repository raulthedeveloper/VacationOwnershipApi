using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VacationOwnershipApi.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Sales> Sales { get; set; }
    }
}
