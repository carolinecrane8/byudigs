using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace byudigs.Models
{
    public partial class Date
    {
        public Date()
        {
            Burial = new HashSet<Burial>();
        }

        public int DateId { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }
    }
}
