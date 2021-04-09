using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace byudigs.Models
{
    public partial class byu_digsContext : DbContext
    {
        public byu_digsContext()
        {
        }

        public byu_digsContext(DbContextOptions<byu_digsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Burial> Burial { get; set; }
        public virtual DbSet<BurialAdvanced> BurialAdvanced { get; set; }
        public virtual DbSet<Cranial> Cranial { get; set; }
        public virtual DbSet<Date> Date { get; set; }
        public virtual DbSet<Plot> Plot { get; set; }
        public virtual DbSet<Sublocation> Sublocation { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = database-1.cfeuysvujco9.us-east-2.rds.amazonaws.com,1433;Initial Catalog = byu_digs; User Id = admin; Password = intex123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Burial>(entity =>
            {
                entity.ToTable("burial");

                entity.Property(e => e.BurialId)
                    .HasColumnName("burial_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BagNum).HasColumnName("bag_num");

                entity.Property(e => e.BurialNum).HasColumnName("burial_num");

                entity.Property(e => e.BurialSubnum).HasColumnName("burial_subnum");

                entity.Property(e => e.DateId).HasColumnName("date_id");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PlotId).HasColumnName("plot_id");

                entity.Property(e => e.PreviouslySampled).HasColumnName("previously_sampled");

                entity.Property(e => e.RackNum).HasColumnName("rack_num");

                entity.Property(e => e.SublocationId).HasColumnName("sublocation_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.DateId)
                    .HasConstraintName("FK_burial_date");

                entity.HasOne(d => d.Plot)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.PlotId)
                    .HasConstraintName("FK_burial_plot");

                entity.HasOne(d => d.Sublocation)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.SublocationId)
                    .HasConstraintName("FK_burial_sublocation");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_burial_users");
            });

            modelBuilder.Entity<BurialAdvanced>(entity =>
            {
                entity.HasKey(e => e.AdvancedId);

                entity.ToTable("burial_advanced");

                entity.Property(e => e.AdvancedId)
                    .HasColumnName("advanced_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArtifactFound).HasColumnName("artifact_found");

                entity.Property(e => e.ArtifactsDescription)
                    .HasColumnName("artifacts_description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BasilarSuture)
                    .HasColumnName("basilar_suture")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BasionBregmaHeight).HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion).HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength).HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter).HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.BoneLength).HasColumnName("bone_length");

                entity.Property(e => e.BoneTaken).HasColumnName("bone_taken");

                entity.Property(e => e.BurialDepth).HasColumnName("burial_depth");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.BurialSituation)
                    .HasColumnName("burial_situation")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CranialStructure)
                    .HasColumnName("cranial_structure")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DayFound).HasColumnName("day_found");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasColumnName("description_of_taken")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsal_pitting");

                entity.Property(e => e.EastToFeet).HasColumnName("east_to_feet");

                entity.Property(e => e.EastToHead).HasColumnName("east_to_head");

                entity.Property(e => e.EpiphysealUnion)
                    .HasColumnName("epiphyseal_union")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstimateAge).HasColumnName("estimate_age");

                entity.Property(e => e.EstimateLivingStature)
                    .HasColumnName("estimate_living_stature")
                    .HasColumnType("numeric(18, 9)");

                entity.Property(e => e.FemurDiameter).HasColumnName("femur_diameter");

                entity.Property(e => e.FemurHead).HasColumnName("femur_head");

                entity.Property(e => e.FemurLength).HasColumnName("femur_length");

                entity.Property(e => e.ForemanMagnum)
                    .HasColumnName("foreman_magnum")
                    .HasColumnType("numeric(18, 9)");

                entity.Property(e => e.GeFunctionTotal)
                    .HasColumnName("GE_function_total")
                    .HasColumnType("numeric(18, 9)");

                entity.Property(e => e.GenderBodyCol)
                    .HasColumnName("gender_body_col")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GenderGe)
                    .HasColumnName("gender_GE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gonian).HasColumnName("gonian");

                entity.Property(e => e.HairColor)
                    .HasColumnName("hair_color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HairTaken).HasColumnName("hair_taken");

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Humerous).HasColumnName("humerous");

                entity.Property(e => e.HumerousHead).HasColumnName("humerous_head");

                entity.Property(e => e.HumerusLength).HasColumnName("humerus_length");

                entity.Property(e => e.IliacCrest).HasColumnName("iliac_crest");

                entity.Property(e => e.InterorbitalBreadth).HasColumnName("interorbital_breadth");

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.MaximumCranialBreadth).HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength).HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth).HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MedialClavicle).HasColumnName("medial_clavicle");

                entity.Property(e => e.MedialIpRamus).HasColumnName("medial_IP_ramus");

                entity.Property(e => e.MonthFound)
                    .HasColumnName("month_found")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NasionProsthion).HasColumnName("nasion_prosthion");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitEdge).HasColumnName("orbit_edge");

                entity.Property(e => e.Osteophytosis)
                    .HasColumnName("osteophytosis")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ParietalBossing).HasColumnName("parietal_bossing");

                entity.Property(e => e.PathologyAnomalies)
                    .HasColumnName("pathology_anomalies")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaur_sulcus");

                entity.Property(e => e.PreservationIndex)
                    .HasColumnName("preservation_index")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublicBone).HasColumnName("public_bone");

                entity.Property(e => e.PublicSymphysis)
                    .HasColumnName("public_symphysis")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.SciaticNotch).HasColumnName("sciatic_notch");

                entity.Property(e => e.SoftTissueTaken).HasColumnName("soft_tissue_taken");

                entity.Property(e => e.SouthToFeet).HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead).HasColumnName("south_to_head");

                entity.Property(e => e.SubpublicAngle).HasColumnName("subpublic_angle");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbital_ridges");

                entity.Property(e => e.TextileTaken).HasColumnName("textile_taken");

                entity.Property(e => e.TibiaLength).HasColumnName("tibia_length");

                entity.Property(e => e.ToothAttrition)
                    .HasColumnName("tooth_attrition")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToothEruption)
                    .HasColumnName("tooth_eruption")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToothTaken).HasColumnName("tooth_taken");

                entity.Property(e => e.VentralArc).HasColumnName("ventral_arc");

                entity.Property(e => e.YearFound).HasColumnName("year_found");

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomatic_crest");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.BurialAdvanced)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("FK_burial_advanced_burial");
            });

            modelBuilder.Entity<Cranial>(entity =>
            {
                entity.ToTable("cranial");

                entity.Property(e => e.CranialId)
                    .HasColumnName("cranial_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.C14Sample2017).HasColumnName("C14_sample_2017");

                entity.Property(e => e.Calibrated95CalendarDateAvg)
                    .HasColumnName("calibrated_95%_calendar_date_AVG")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Calibrated95CalendarDateMax)
                    .HasColumnName("calibrated_95%_calendar_date_MAX")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Calibrated95CalendarDateMin)
                    .HasColumnName("calibrated_95%_calendar_date_MIN")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Calibrated95CalendarDateSpan)
                    .HasColumnName("calibrated_95%_calendar_date_SPAN")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Conventional14cAgeBp).HasColumnName("conventional_14C_age_BP");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.LabNotes)
                    .HasColumnName("lab_notes")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasColumnName("location")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SizeMl).HasColumnName("size_ml");

                entity.Property(e => e.TubeNum).HasColumnName("tube_num");

                entity.Property(e => e._14cCalendarDate)
                    .HasColumnName("14C_calendar_date")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.Cranial)
                    .HasForeignKey(d => d.BurialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cranial_burial");
            });

            modelBuilder.Entity<Date>(entity =>
            {
                entity.ToTable("date");

                entity.Property(e => e.DateId)
                    .HasColumnName("date_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Day).HasColumnName("day");

                entity.Property(e => e.Month).HasColumnName("month");

                entity.Property(e => e.Year).HasColumnName("year");
            });

            modelBuilder.Entity<Plot>(entity =>
            {
                entity.ToTable("plot");

                entity.Property(e => e.PlotId)
                    .HasColumnName("plot_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialLocationEw)
                    .HasColumnName("burial_location_ew")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BurialLocationNs)
                    .HasColumnName("burial_location_ns")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HighPairEw).HasColumnName("high_pair_ew");

                entity.Property(e => e.HighPairNs).HasColumnName("high_pair_ns");

                entity.Property(e => e.LowPairEw).HasColumnName("low_pair_ew");

                entity.Property(e => e.LowPairNs).HasColumnName("low_pair_ns");
            });

            modelBuilder.Entity<Sublocation>(entity =>
            {
                entity.ToTable("sublocation");

                entity.Property(e => e.SublocationId)
                    .HasColumnName("sublocation_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direction)
                    .HasColumnName("direction")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tomb)
                    .HasColumnName("tomb")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_user");

                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserInitials)
                    .HasColumnName("user_initials")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("user_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
