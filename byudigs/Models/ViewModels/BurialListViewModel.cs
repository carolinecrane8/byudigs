using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace byudigs.Models.ViewModels
{
    public class BurialListViewModel
    {
        //these are the fields which will be passed to the strongly-typed view. This class is basically a bundle that gets passed to the view

        //needs a public IEnumerable for each table that is being passed to the view
        public IEnumerable<BurialAdvanced> Burials { get; set; }
        public IEnumerable<BurialAdvanced> PlotBurials { get; set; }

        public PageNumberingInfo PageNumberingInfo { get; set; }


        //maybe a nullable field for each category of filter that we will use
        public string? HairColor { get; set; }
    }
}
