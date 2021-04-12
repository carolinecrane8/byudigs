using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace byudigs.Models.ViewModels
{
    public class ViewModel
    {
        public Burial burial { get; set; }
        public BurialAdvanced burialadvanced { get; set; }
        public Plot plot { get; set; }
        public Sublocation sublocation { get; set; }
    }
}
