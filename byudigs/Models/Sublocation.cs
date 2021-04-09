using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace byudigs.Models
{
    public partial class Sublocation
    {
        public Sublocation()
        {
            Burial = new HashSet<Burial>();
        }

        public int SublocationId { get; set; }
        public string Direction { get; set; }
        public string Area { get; set; }
        public string Tomb { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }
    }
}
