using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace byudigs.Models
{
    public partial class Burial
    {
        public Burial()
        {
            BurialAdvanced = new HashSet<BurialAdvanced>();
            Cranial = new HashSet<Cranial>();
        }

        public int BurialId { get; set; }
        public int? RackNum { get; set; }
        public int? BagNum { get; set; }
        public int? BurialNum { get; set; }
        public int? BurialSubnum { get; set; }
        public bool? PreviouslySampled { get; set; }
        public string Notes { get; set; }
        public int? PlotId { get; set; }
        public int? SublocationId { get; set; }
        public int? UserId { get; set; }
        public int? DateId { get; set; }

        public virtual Date Date { get; set; }
        public virtual Plot Plot { get; set; }
        public virtual Sublocation Sublocation { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<BurialAdvanced> BurialAdvanced { get; set; }
        public virtual ICollection<Cranial> Cranial { get; set; }
    }
}
