using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

public partial class ChandigarhEstatesContext : DbContext
{
    public ChandigarhEstatesContext()
    {
    }

    public ChandigarhEstatesContext(DbContextOptions<ChandigarhEstatesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CityTable> CityTables { get; set; }

    public virtual DbSet<CompanyContactDetail> CompanyContactDetails { get; set; }

    public virtual DbSet<CompanyDetail> CompanyDetails { get; set; }

    public virtual DbSet<CountryTable> CountryTables { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<ManageCustomer> ManageCustomers { get; set; }

    public virtual DbSet<ManagePlot> ManagePlots { get; set; }

    public virtual DbSet<RegistrationTable> RegistrationTables { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StateTable> StateTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GFSMDEQ; Database=ChandigarhEstates; Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CityTable>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK_City_Table1");

            entity.ToTable("City_Table");

            entity.Property(e => e.CityId).ValueGeneratedNever();
            entity.Property(e => e.CityName).HasMaxLength(50);
        });

        modelBuilder.Entity<CompanyContactDetail>(entity =>
        {
            entity.ToTable("CompanyContactDetail");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ContactPersonDesignation).HasMaxLength(50);
            entity.Property(e => e.ContactPersonEmailId).HasMaxLength(50);
            entity.Property(e => e.ContactPersonName).HasMaxLength(50);
            entity.Property(e => e.ContactPersonPhoneNo).HasMaxLength(50);

            entity.HasOne(d => d.Company).WithMany(p => p.CompanyContactDetails)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_CompanyContactDetail_CompanyDetail");
        });

        modelBuilder.Entity<CompanyDetail>(entity =>
        {
            entity.HasKey(e => e.CompanyId);

            entity.ToTable("CompanyDetail");

            entity.Property(e => e.CompanyName).HasMaxLength(50);
            entity.Property(e => e.ContactNo).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Pin).HasMaxLength(50);

            entity.HasOne(d => d.City).WithMany(p => p.CompanyDetails)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_CompanyDetail_City_Table");

            entity.HasOne(d => d.State).WithMany(p => p.CompanyDetails)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_CompanyDetail_State_Table");
        });

        modelBuilder.Entity<CountryTable>(entity =>
        {
            entity.HasKey(e => e.CountryId);

            entity.ToTable("Country_Table");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Login_3214EC07F45F11F4");

            entity.ToTable("Login");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasDefaultValueSql("((2))");

            entity.HasOne(d => d.Reg).WithMany(p => p.Logins)
                .HasForeignKey(d => d.RegId)
                .HasConstraintName("FK_Login_Registration_Table");
        });

        modelBuilder.Entity<ManageCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("ManageCustomer");

            entity.Property(e => e.Contact).HasMaxLength(50);
            entity.Property(e => e.CustomerEmail).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.ParentName).HasMaxLength(50);
            entity.Property(e => e.PlotSize).HasMaxLength(50);
        });

        modelBuilder.Entity<ManagePlot>(entity =>
        {
            entity.ToTable("ManagePlot");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Block).HasMaxLength(50);
            entity.Property(e => e.PlotNo).HasMaxLength(50);
            entity.Property(e => e.Price).HasMaxLength(50);
            entity.Property(e => e.TokenAmount).HasMaxLength(50);
            entity.Property(e => e.Unit).HasMaxLength(50);
        });

        modelBuilder.Entity<RegistrationTable>(entity =>
        {
            entity.HasKey(e => e.RegId);

            entity.ToTable("Registration_Table");

            entity.Property(e => e.Fname).HasMaxLength(50);
            entity.Property(e => e.Lname).HasMaxLength(50);
            entity.Property(e => e.PhoneNo).HasMaxLength(50);

            entity.HasOne(d => d.City).WithMany(p => p.RegistrationTables)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Registration_Table_City_Table");

            entity.HasOne(d => d.Country).WithMany(p => p.RegistrationTables)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Registration_Table_Country_Table");

            entity.HasOne(d => d.State).WithMany(p => p.RegistrationTables)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_Registration_Table_State_Table1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<StateTable>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK_State_Table1");

            entity.ToTable("State_Table");

            entity.Property(e => e.StateId).ValueGeneratedNever();
            entity.Property(e => e.StateName).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.StateTables)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_State_Table_Country_Table");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
