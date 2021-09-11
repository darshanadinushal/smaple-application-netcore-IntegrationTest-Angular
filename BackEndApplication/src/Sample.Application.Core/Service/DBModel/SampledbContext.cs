using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

//>>Scaffold-DbContext "Data Source=LAPTOP-B4GI3VF3;Initial Catalog=sampledb;User ID=sa;Password=dar123;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Service/DBModel

namespace Sample.Application.Core.Service.DBModel
{
    public partial class SampledbContext : DbContext
    {
        public SampledbContext(DbContextOptions<SampledbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblEmployee> TblEmployee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifitedBy).HasColumnType("datetime");

                entity.Property(e => e.ModifitedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.ModifitedDate).HasColumnType("datetime");

                entity.Property(e => e.Phone).IsRequired();

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.TblEmployee)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TblEmployee_TblDepartment");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
