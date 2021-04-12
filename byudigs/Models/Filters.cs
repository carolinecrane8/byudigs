using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace byudigs.Models
{
    public class Filters
    {

        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all-all-all";
            string[] filters = FilterString.Split('-');
            HairKey = filters[0];
            GenderKey = filters[1];
            LocationKey = filters[2];
            HeadDirectionKey = filters[3];
            PreservationKey = filters[4];
        }

        public string FilterString { get; }
        public string HairKey { get; }
        public string GenderKey { get; }
        public string LocationKey { get; }
        public string HeadDirectionKey { get; }
        public string PreservationKey { get; }
        public string ArtifactFoundKey { get; }

        public bool HasHair => HairKey.ToLower() != "all";
        public bool HasGender => GenderKey.ToLower() != "all";
        public bool HasLocation => LocationKey.ToLower() != "all";
        public bool HasHeadDirection => HeadDirectionKey.ToLower() != "all";
        public bool HasPreservationIndex => PreservationKey.ToLower() != "all";
    }
}
