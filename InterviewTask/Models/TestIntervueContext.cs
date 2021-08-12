using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.IdentityModel.Protocols;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
 #nullable disable

namespace InterviewTask.Models
{
    public partial class TestIntervueContext : DbContext
    {
        public TestIntervueContext()
        {
        }

        public TestIntervueContext(DbContextOptions<TestIntervueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Dictionary> Dictionary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Name=TestIntervue");
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dictionary>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Chinese).HasMaxLength(255);

                entity.Property(e => e.English).HasMaxLength(255);

                entity.Property(e => e.Hungarian).HasMaxLength(255);

                entity.Property(e => e.Portuguese).HasMaxLength(255);

                entity.Property(e => e.Spanish).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
