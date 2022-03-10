using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VacationOwnershipApi.Models
{
    public partial class Unit
    {
        public Unit()
        {
            Sales = new HashSet<Sales>();
        }

        public int Id { get; set; }
        public int ResortId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public bool? Purchased { get; set; }

        public virtual Resort Resort { get; set; }
        public virtual ICollection<Sales> Sales { get; set; }
    }
}
