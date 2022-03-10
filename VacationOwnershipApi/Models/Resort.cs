using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace VacationOwnershipApi.Models
{
    public partial class Resort
    {
        public Resort()
        {
            Unit = new HashSet<Unit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Unit> Unit { get; set; }
    }
}
