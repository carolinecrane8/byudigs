using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace byudigs.Models
{
    public partial class Cranial
    {
        public int CranialId { get; set; }
        public int BurialId { get; set; }
        public int? TubeNum { get; set; }
        public string Description { get; set; }
        public int? SizeMl { get; set; }
        public int? Foci { get; set; }
        public int? C14Sample2017 { get; set; }
        public string Location { get; set; }
        public string Question { get; set; }
        public int? Conventional14cAgeBp { get; set; }
        public string _14cCalendarDate { get; set; }
        public string Calibrated95CalendarDateMax { get; set; }
        public string Calibrated95CalendarDateMin { get; set; }
        public string Calibrated95CalendarDateSpan { get; set; }
        public string Calibrated95CalendarDateAvg { get; set; }
        public string Category { get; set; }
        public string LabNotes { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
