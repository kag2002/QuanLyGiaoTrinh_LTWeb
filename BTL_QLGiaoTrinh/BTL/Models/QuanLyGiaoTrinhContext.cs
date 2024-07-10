using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTL.Models;

public partial class QuanLyGiaoTrinhContext : DbContext
{
    public QuanLyGiaoTrinhContext()
    {
    }

    public QuanLyGiaoTrinhContext(DbContextOptions<QuanLyGiaoTrinhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Baocao3> Baocao3s { get; set; }

    public virtual DbSet<ChiTietHsmuon> ChiTietHsmuons { get; set; }

    public virtual DbSet<ChiTietHstra> ChiTietHstras { get; set; }

    public virtual DbSet<ChuyenNganh> ChuyenNganhs { get; set; }

    public virtual DbSet<DmgiaoTrinh> DmgiaoTrinhs { get; set; }

    public virtual DbSet<HoSoTra> HoSoTras { get; set; }

    public virtual DbSet<Hsmuon> Hsmuons { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<Phat> Phats { get; set; }

    public virtual DbSet<Que> Ques { get; set; }

    public virtual DbSet<TacGium> TacGia { get; set; }

    public virtual DbSet<TheMuon> TheMuons { get; set; }

    public virtual DbSet<ThuThu> ThuThus { get; set; }

    public virtual DbSet<TrinhDo> TrinhDos { get; set; }

    public virtual DbSet<ViPham> ViPhams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS01;Initial Catalog=QuanLyGiaoTrinh;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Baocao3>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("baocao3");

            entity.Property(e => e.ChuaTra)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.MaGt)
                .HasMaxLength(30)
                .HasColumnName("MaGT");
            entity.Property(e => e.MaHsm)
                .HasMaxLength(30)
                .HasColumnName("MaHSM");
            entity.Property(e => e.MaThe).HasMaxLength(30);
            entity.Property(e => e.MaThuThu).HasMaxLength(30);
            entity.Property(e => e.NgayMuon).HasColumnType("datetime");
            entity.Property(e => e.NgayTra).HasColumnType("datetime");
            entity.Property(e => e.TinhTrangMuon).HasMaxLength(30);
        });

        modelBuilder.Entity<ChiTietHsmuon>(entity =>
        {
            entity.HasKey(e => new { e.MaHsm, e.MaGt });

            entity.ToTable("ChiTietHSMuon");

            entity.Property(e => e.MaHsm)
                .HasMaxLength(30)
                .HasColumnName("MaHSM");
            entity.Property(e => e.MaGt)
                .HasMaxLength(30)
                .HasColumnName("MaGT");
            entity.Property(e => e.ChuaTra)
                .HasMaxLength(30)
                .IsFixedLength();

            entity.HasOne(d => d.MaGtNavigation).WithMany(p => p.ChiTietHsmuons)
                .HasForeignKey(d => d.MaGt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHSMuon_DMGiaoTrinh");

            entity.HasOne(d => d.MaHsmNavigation).WithMany(p => p.ChiTietHsmuons)
                .HasForeignKey(d => d.MaHsm)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHSMuon_HSMuon");
        });

        modelBuilder.Entity<ChiTietHstra>(entity =>
        {
            entity.HasKey(e => new { e.MaHstra, e.MaGt });

            entity.ToTable("ChiTietHSTra");

            entity.Property(e => e.MaHstra)
                .HasMaxLength(30)
                .HasColumnName("MaHSTra");
            entity.Property(e => e.MaGt)
                .HasMaxLength(30)
                .HasColumnName("MaGT");
            entity.Property(e => e.MaPhat).HasMaxLength(30);
            entity.Property(e => e.MaViPham).HasMaxLength(30);

            entity.HasOne(d => d.MaHstraNavigation).WithMany(p => p.ChiTietHstras)
                .HasForeignKey(d => d.MaHstra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHSTra_HoSoTra");

            entity.HasOne(d => d.MaPhatNavigation).WithMany(p => p.ChiTietHstras)
                .HasForeignKey(d => d.MaPhat)
                .HasConstraintName("FK_ChiTietHSTra_Phat");

            entity.HasOne(d => d.MaViPhamNavigation).WithMany(p => p.ChiTietHstras)
                .HasForeignKey(d => d.MaViPham)
                .HasConstraintName("FK_ChiTietHSTra_ViPham");
        });

        modelBuilder.Entity<ChuyenNganh>(entity =>
        {
            entity.HasKey(e => e.MaChuyenNganh);

            entity.ToTable("ChuyenNganh");

            entity.Property(e => e.MaChuyenNganh).HasMaxLength(30);
            entity.Property(e => e.TenChuyenNganh).HasMaxLength(100);
        });

        modelBuilder.Entity<DmgiaoTrinh>(entity =>
        {
            entity.HasKey(e => e.MaGt);

            entity.ToTable("DMGiaoTrinh");

            entity.Property(e => e.MaGt)
                .HasMaxLength(30)
                .HasColumnName("MaGT");
            entity.Property(e => e.Anh).HasMaxLength(255);
            entity.Property(e => e.LanTb).HasColumnName("LanTB");
            entity.Property(e => e.MaChuyenNganh).HasMaxLength(30);
            entity.Property(e => e.MaTacGia).HasMaxLength(30);
            entity.Property(e => e.NamXb).HasColumnName("NamXB");
            entity.Property(e => e.SoLuongGt).HasColumnName("SoLuongGT");
            entity.Property(e => e.TenGt)
                .HasMaxLength(200)
                .HasColumnName("TenGT");
            entity.Property(e => e.TomTatNd)
                .HasMaxLength(300)
                .HasColumnName("TomTatND");

            entity.HasOne(d => d.MaChuyenNganhNavigation).WithMany(p => p.DmgiaoTrinhs)
                .HasForeignKey(d => d.MaChuyenNganh)
                .HasConstraintName("FK_DMGiaoTrinh_ChuyenNganh");

            entity.HasOne(d => d.MaTacGiaNavigation).WithMany(p => p.DmgiaoTrinhs)
                .HasForeignKey(d => d.MaTacGia)
                .HasConstraintName("FK_DMGiaoTrinh_TacGia");
        });

        modelBuilder.Entity<HoSoTra>(entity =>
        {
            entity.HasKey(e => e.MaHstra);

            entity.ToTable("HoSoTra");

            entity.Property(e => e.MaHstra)
                .HasMaxLength(30)
                .HasColumnName("MaHSTra");
            entity.Property(e => e.MaHsm)
                .HasMaxLength(30)
                .HasColumnName("MaHSM");
            entity.Property(e => e.MaThuThu).HasMaxLength(30);
            entity.Property(e => e.NgayNopPhat).HasColumnType("datetime");
            entity.Property(e => e.NgayTra).HasColumnType("datetime");
            entity.Property(e => e.TongTienPhat).HasColumnType("money");

            entity.HasOne(d => d.MaThuThuNavigation).WithMany(p => p.HoSoTras)
                .HasForeignKey(d => d.MaThuThu)
                .HasConstraintName("FK_HoSoTra_ThuThu");
        });

        modelBuilder.Entity<Hsmuon>(entity =>
        {
            entity.HasKey(e => e.MaHsm);

            entity.ToTable("HSMuon");

            entity.Property(e => e.MaHsm)
                .HasMaxLength(30)
                .HasColumnName("MaHSM");
            entity.Property(e => e.MaThe).HasMaxLength(30);
            entity.Property(e => e.MaThuThu).HasMaxLength(30);
            entity.Property(e => e.NgayMuon).HasColumnType("datetime");
            entity.Property(e => e.NgayTra).HasColumnType("datetime");
            entity.Property(e => e.TinhTrangMuon).HasMaxLength(30);

            entity.HasOne(d => d.MaTheNavigation).WithMany(p => p.Hsmuons)
                .HasForeignKey(d => d.MaThe)
                .HasConstraintName("FK_HSMuon_TheMuon");

            entity.HasOne(d => d.MaThuThuNavigation).WithMany(p => p.Hsmuons)
                .HasForeignKey(d => d.MaThuThu)
                .HasConstraintName("FK_HSMuon_ThuThu");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa);

            entity.ToTable("Khoa");

            entity.Property(e => e.MaKhoa).HasMaxLength(30);
            entity.Property(e => e.Sdt)
                .HasMaxLength(30)
                .HasColumnName("SDT");
            entity.Property(e => e.TenKhoa).HasMaxLength(30);
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop);

            entity.ToTable("Lop");

            entity.Property(e => e.MaLop).HasMaxLength(30);
            entity.Property(e => e.MaKhoa).HasMaxLength(30);
            entity.Property(e => e.TenLop).HasMaxLength(30);
        });

        modelBuilder.Entity<Phat>(entity =>
        {
            entity.HasKey(e => e.MaPhat);

            entity.ToTable("Phat");

            entity.Property(e => e.MaPhat).HasMaxLength(30);
            entity.Property(e => e.TienPhat).HasColumnType("money");
        });

        modelBuilder.Entity<Que>(entity =>
        {
            entity.HasKey(e => e.MaQue);

            entity.ToTable("Que");

            entity.Property(e => e.MaQue).HasMaxLength(30);
            entity.Property(e => e.TenQue).HasMaxLength(30);
        });

        modelBuilder.Entity<TacGium>(entity =>
        {
            entity.HasKey(e => e.MaTacGia);

            entity.Property(e => e.MaTacGia).HasMaxLength(30);
            entity.Property(e => e.MaKhoa).HasMaxLength(30);
            entity.Property(e => e.MaTrinhDo).HasMaxLength(30);
            entity.Property(e => e.TenTacGia).HasMaxLength(30);

            entity.HasOne(d => d.MaKhoaNavigation).WithMany(p => p.TacGia)
                .HasForeignKey(d => d.MaKhoa)
                .HasConstraintName("FK_tacgia_khoa");

            entity.HasOne(d => d.MaTrinhDoNavigation).WithMany(p => p.TacGia)
                .HasForeignKey(d => d.MaTrinhDo)
                .HasConstraintName("FK_tacgia_trinhdo");
        });

        modelBuilder.Entity<TheMuon>(entity =>
        {
            entity.HasKey(e => e.MaThe);

            entity.ToTable("TheMuon");

            entity.Property(e => e.MaThe).HasMaxLength(30);
            entity.Property(e => e.GioiTinh).HasMaxLength(30);
            entity.Property(e => e.HoTen).HasMaxLength(30);
            entity.Property(e => e.KhoaThe)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.MaKhoa).HasMaxLength(30);
            entity.Property(e => e.MaLop).HasMaxLength(30);
            entity.Property(e => e.Slmuon).HasColumnName("SLMuon");

            entity.HasOne(d => d.MaLopNavigation).WithMany(p => p.TheMuons)
                .HasForeignKey(d => d.MaLop)
                .HasConstraintName("FK_TheMuon_Lop");
        });

        modelBuilder.Entity<ThuThu>(entity =>
        {
            entity.HasKey(e => e.MaThuThu);

            entity.ToTable("ThuThu");

            entity.Property(e => e.MaThuThu).HasMaxLength(30);
            entity.Property(e => e.DiaChi).HasMaxLength(30);
            entity.Property(e => e.DienThoaiCd)
                .HasMaxLength(30)
                .HasColumnName("DienThoaiCD");
            entity.Property(e => e.DienThoaiDd)
                .HasMaxLength(30)
                .HasColumnName("DienThoaiDD");
            entity.Property(e => e.MaQue).HasMaxLength(30);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.TenThuThu).HasMaxLength(30);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.MaQueNavigation).WithMany(p => p.ThuThus)
                .HasForeignKey(d => d.MaQue)
                .HasConstraintName("FK_ThuThu_Que");
        });

        modelBuilder.Entity<TrinhDo>(entity =>
        {
            entity.HasKey(e => e.MaTrinhDo);

            entity.ToTable("TrinhDo");

            entity.Property(e => e.MaTrinhDo).HasMaxLength(30);
            entity.Property(e => e.TenTrinhDo).HasMaxLength(30);
        });

        modelBuilder.Entity<ViPham>(entity =>
        {
            entity.HasKey(e => e.MaViPham);

            entity.ToTable("ViPham");

            entity.Property(e => e.MaViPham).HasMaxLength(30);
            entity.Property(e => e.TenViPham).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
