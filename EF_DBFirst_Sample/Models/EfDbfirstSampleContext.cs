using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_DBFirst_Sample.Models;

public partial class EfDbfirstSampleContext : DbContext
{
    public EfDbfirstSampleContext()
    {
    }

    public EfDbfirstSampleContext(DbContextOptions<EfDbfirstSampleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-0TDNQCQ\\SQLEXPRESS;Initial Catalog=EF_DBFirst_Sample;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Khoa__3214EC0716814E50");

            entity.ToTable("Khoa");

            entity.Property(e => e.TenKhoa).HasMaxLength(255);
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lop__3214EC07F03A499C");

            entity.ToTable("Lop");

            entity.Property(e => e.TenLop).HasMaxLength(255);

            entity.HasOne(d => d.Khoa).WithMany(p => p.Lops)
                .HasForeignKey(d => d.KhoaId)
                .HasConstraintName("FK__Lop__KhoaId__267ABA7A");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SinhVien__3214EC071842BE01");

            entity.ToTable("SinhVien");

            entity.Property(e => e.HoTen).HasMaxLength(255);
            entity.Property(e => e.NgaySinh).HasColumnType("date");

            entity.HasOne(d => d.Lop).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.LopId)
                .HasConstraintName("FK__SinhVien__LopId__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
