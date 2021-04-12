using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace byudigs.Models
{
    public partial class BurialAdvanced
    {
        public int AdvancedId { get; set; }
        //I made this b a string
        public int? BurialId { get; set; }
        public double? BurialDepth { get; set; }
        public int? SouthToHead { get; set; }
        public int? SouthToFeet { get; set; }
        public int? EastToHead { get; set; }
        public int? EastToFeet { get; set; }
        public string BurialSituation { get; set; }
        public int? LengthOfRemains { get; set; }
        public string GenderGe { get; set; }
        public decimal? GeFunctionTotal { get; set; }
        public string GenderBodyCol { get; set; }
        public string BasilarSuture { get; set; }
        public int? VentralArc { get; set; }
        public int? SubpublicAngle { get; set; }
        public int? SciaticNotch { get; set; }
        public int? PublicBone { get; set; }
        public int? PreaurSulcus { get; set; }
        public int? MedialIpRamus { get; set; }
        public int? DorsalPitting { get; set; }
        public decimal? ForemanMagnum { get; set; }
        public double? FemurHead { get; set; }
        public double? HumerousHead { get; set; }
        public string Osteophytosis { get; set; }
        public string PublicSymphysis { get; set; }
        public double? BoneLength { get; set; }
        public double? MedialClavicle { get; set; }
        public double? IliacCrest { get; set; }
        public double? FemurDiameter { get; set; }
        public double? Humerous { get; set; }
        public double? FemurLength { get; set; }
        public double? HumerusLength { get; set; }
        public double? TibiaLength { get; set; }
        public int? Robust { get; set; }
        public int? SupraorbitalRidges { get; set; }
        public int? OrbitEdge { get; set; }
        public int? ParietalBossing { get; set; }
        public int? Gonian { get; set; }
        public int? NuchalCrest { get; set; }
        public int? ZygomaticCrest { get; set; }
        public string CranialStructure { get; set; }
        public double? MaximumCranialLength { get; set; }
        public double? MaximumCranialBreadth { get; set; }
        public double? BasionBregmaHeight { get; set; }
        public double? BasionNasion { get; set; }
        public double? BasionProsthionLength { get; set; }
        public double? BizygomaticDiameter { get; set; }
        public double? NasionProsthion { get; set; }
        public double? MaximumNasalBreadth { get; set; }
        public double? InterorbitalBreadth { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColor { get; set; }
        public string PreservationIndex { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public bool? TextileTaken { get; set; }
        public string DescriptionOfTaken { get; set; }
        public bool? ArtifactFound { get; set; }
        public double? EstimateAge { get; set; }
        public decimal? EstimateLivingStature { get; set; }
        public string ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public string PathologyAnomalies { get; set; }
        public string EpiphysealUnion { get; set; }
        public int? YearFound { get; set; }
        public string MonthFound { get; set; }
        public int? DayFound { get; set; }
        public string HeadDirection { get; set; }

        public virtual Burial Burial { get; set; }
    }
}
