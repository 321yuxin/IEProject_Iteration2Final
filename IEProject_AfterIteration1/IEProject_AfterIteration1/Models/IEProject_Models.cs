namespace IEProject_AfterIteration1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IEProject_Models : DbContext
    {
        public IEProject_Models()
            : base("name=IEProject_Models")
        {
        }

        public virtual DbSet<Housing> Housings { get; set; }
        public virtual DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Housing>()
                .Property(e => e.Suburb)
                .IsUnicode(false);

            modelBuilder.Entity<School>()
                .Property(e => e.Suburb)
                .IsUnicode(false);
        }

        //public System.Data.Entity.DbSet<IEProject_AfterIteration1.Models.House_Rating> House_Rating { get; set; }

        //public System.Data.Entity.DbSet<IEProject_AfterIteration1.Models.Updated_Result> Updated_Result { get; set; }
    }
}
