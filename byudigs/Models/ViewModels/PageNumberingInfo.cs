using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace byudigs.Models.ViewModels
{
    public class PageNumberingInfo
    {
        //info to get from controller, pass to view as defaults for the structure of the page
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNumItems { get; set; }

        //calculate pages
        //cast one of the properties as a decimal to force decimal division
        public int NumPages => (int)Math.Ceiling((decimal)TotalNumItems / NumItemsPerPage);
    }
}