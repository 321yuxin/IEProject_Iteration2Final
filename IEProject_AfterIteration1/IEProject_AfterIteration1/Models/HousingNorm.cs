namespace IEProject_AfterIteration1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HousingNorm : DbContext
    {
        public HousingNorm()
            : base("name=HousingNorm")
        {
        }

        public virtual DbSet<Housing> Housings { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<SuperMarket> SuperMarkets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Housing>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Station>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Station>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<SuperMarket>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<SuperMarket>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<SuperMarket>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<SuperMarket>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);
        }
    }
}
