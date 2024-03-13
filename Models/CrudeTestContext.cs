using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CrudeOprationTest.Models;

public partial class CrudeTestContext : DbContext
{
    public CrudeTestContext()
    {
    }

    public CrudeTestContext(DbContextOptions<CrudeTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employee1> Employees1 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=crudeTest;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__Employee__AF2D66D31AF75545");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpNo).ValueGeneratedNever();
            entity.Property(e => e.BasicSalary)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee1>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__Employee__AF2D66D3BCF5CF2E");

            entity.ToTable("Employees");

            entity.Property(e => e.EmpNo).ValueGeneratedNever();
            entity.Property(e => e.BasicSalary)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 3)");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
