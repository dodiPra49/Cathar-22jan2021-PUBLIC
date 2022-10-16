using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using New.Models;
//using New.ViewModel;

namespace New.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbQuery<HKYbsJam> HKYbsJam { get; set; }
        public virtual DbSet<Diary> Diary { get; set; }
        public virtual DbSet<updatepuasaSP> updatepuasaSP { get; set; }
        public virtual DbSet<HariKerja> HariKerja { get; set; }
        public virtual DbSet<HariKerjaNip> HariKerjaNip { get; set; }
        public virtual DbSet<HariKerjaStatus> HariKerjaStatus { get; set; }
        public virtual DbSet<Jabatan> Jabatan { get; set; }
        public virtual DbSet<JamKerjaPola> JamKerjaPola { get; set; }
        public virtual DbSet<Pegawai> Pegawai { get; set; }
        public virtual DbSet<Periode> Periode { get; set; }
        public virtual DbSet<PeriodeKaSKPD> PeriodeKaSKPD { get; set; }
        public virtual DbSet<PeriodeNIP> PeriodeNIP { get; set; }
        public virtual DbSet<UnitKerja> UnitKerja { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }
        public virtual DbSet<JamKerjaPolaDt> JamKerjaPolaDt { get; set; }
        public virtual DbSet<ListHari> ListHari { get; set; }
        public virtual DbSet<Rapat> Rapat { get; set; }
        public virtual DbSet<noEntriCathar> noEntriCathar { get; set; }
        //public virtual DbSet<AjukanDiary> AjukanDiary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Diary>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Aktifitas).IsUnicode(false);

                entity.Property(e => e.Hasil).IsUnicode(false);

                entity.Property(e => e.IdPeriode).IsUnicode(false);

                entity.Property(e => e.Nip).IsUnicode(false);

                entity.Property(e => e.Tempat).IsUnicode(false);

                entity.HasOne(d => d.PeriodeNIP)
                    .WithMany(p => p.Diary)
                    .HasForeignKey(d => new { d.IdPeriode, d.Nip })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Diary_PeriodeNIP");
            });

            modelBuilder.Entity<HariKerjaNip>(entity =>
            {
                entity.HasKey(e => new { e.IdPeriode, e.NIP, e.Tanggal });

                entity.Property(e => e.IdPeriode).IsUnicode(false);

                entity.Property(e => e.NIP).IsUnicode(false);

                entity.HasOne(d => d.IdHariKerjaStatusNavigation)
                    .WithMany(p => p.HariKerjaNip)
                    .HasForeignKey(d => d.IdHariKerjaStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HariKerjaNip_HariKerjaStatus");

                entity.HasOne(d => d.PeriodeNIP)
                    .WithMany(p => p.HariKerjaNip)
                    .HasForeignKey(d => new { d.IdPeriode, d.NIP })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HariKerjaNip_PeriodeNIP");
            });

            modelBuilder.Entity<HariKerjaStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Uraian).IsUnicode(false);
            });

            modelBuilder.Entity<Jabatan>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Uraian).IsUnicode(false);

                entity.HasOne(d => d.IdUnitKerjaNavigation)
                    .WithMany(p => p.Jabatan)
                    .HasForeignKey(d => d.IdUnitKerja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jabatan_UnitKerja");
            });

            modelBuilder.Entity<JamKerjaPola>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Uraian).IsUnicode(false);
            });

            modelBuilder.Entity<JamKerjaPolaDt>(entity =>
            {
                entity.HasKey(e => new { e.IdPola, e.IdDow })
                    .HasName("PK_JamPolaDt");

                entity.HasOne(d => d.IdDowNavigation)
                    .WithMany(p => p.JamKerjaPolaDt)
                    .HasForeignKey(d => d.IdDow)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JamKerjaPolaDt_ListHari");

                entity.HasOne(d => d.IdPolaNavigation)
                    .WithMany(p => p.JamKerjaPolaDt)
                    .HasForeignKey(d => d.IdPola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JamKerjaPolaDt_JamKerjaPola");
            });

            modelBuilder.Entity<ListHari>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Uraian).IsUnicode(false);
            });

            modelBuilder.Entity<Pegawai>(entity =>
            {
                entity.Property(e => e.NIP)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.GelarBelakang).IsUnicode(false);

                entity.Property(e => e.GelarDepan).IsUnicode(false);

                entity.Property(e => e.Nama).IsUnicode(false);

                entity.Property(e => e.TempatLahir).IsUnicode(false);
            });

            modelBuilder.Entity<Periode>(entity =>
            {
                entity.Property(e => e.Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<PeriodeKaSKPD>(entity =>
            {
                entity.HasKey(e => new { e.IdPeriode, e.IdUnitKerja });

                entity.Property(e => e.IdPeriode).IsUnicode(false);

                entity.Property(e => e.IdKaSKPD).IsUnicode(false);

                entity.HasOne(d => d.IdJabatanNavigation)
                    .WithMany(p => p.PeriodeKaSKPD)
                    .HasForeignKey(d => d.IdJabatan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeKaSKPD_Jabatan");

                entity.HasOne(d => d.IdKaSKPDNavigation)
                    .WithMany(p => p.PeriodeKaSKPD)
                    .HasForeignKey(d => d.IdKaSKPD)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeKaSKPD_Pegawai");
            });

            modelBuilder.Entity<PeriodeNIP>(entity =>
            {
                entity.HasKey(e => new { e.IdPeriode, e.Nip });

                entity.Property(e => e.IdPeriode).IsUnicode(false);

                entity.Property(e => e.Nip).IsUnicode(false);

                entity.Property(e => e.NipAtas1).IsUnicode(false);

                entity.Property(e => e.NipAtas2).IsUnicode(false);

                entity.HasOne(d => d.IdJabatanNavigation)
                    .WithMany(p => p.PeriodeNIPIdJabatanNavigation)
                    .HasForeignKey(d => d.IdJabatan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeNIP_Jabatan");

                entity.HasOne(d => d.IdJabatanAtas1Navigation)
                    .WithMany(p => p.PeriodeNIPIdJabatanAtas1Navigation)
                    .HasForeignKey(d => d.IdJabatanAtas1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeNIP_Jabatan1");

                entity.HasOne(d => d.IdJabatanAtas2Navigation)
                    .WithMany(p => p.PeriodeNIPIdJabatanAtas2Navigation)
                    .HasForeignKey(d => d.IdJabatanAtas2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeNIP_Jabatan2");

                entity.HasOne(d => d.IdPeriodeNavigation)
                    .WithMany(p => p.PeriodeNIP)
                    .HasForeignKey(d => d.IdPeriode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeNIP_Periode");

                entity.HasOne(d => d.IdUnitKerjaNavigation)
                    .WithMany(p => p.PeriodeNIP)
                    .HasForeignKey(d => d.IdUnitKerja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeNIP_UnitKerja");

                entity.HasOne(d => d.NipNavigation)
                    .WithMany(p => p.PeriodeNIPNipNavigation)
                    .HasForeignKey(d => d.Nip)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeNIP_Pegawai");

                entity.HasOne(d => d.NipAtas1Navigation)
                    .WithMany(p => p.PeriodeNIPNipAtas1Navigation)
                    .HasForeignKey(d => d.NipAtas1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeNIP_Pegawai1");

                entity.HasOne(d => d.NipAtas2Navigation)
                    .WithMany(p => p.PeriodeNIPNipAtas2Navigation)
                    .HasForeignKey(d => d.NipAtas2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeNIP_Pegawai2");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.PeriodeNIP)
                    .HasForeignKey(d => new { d.IdPeriode, d.IdUnitKerja })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodeNIP_PeriodeKaSKPD");
            });

            modelBuilder.Entity<UnitKerja>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Uraian).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<New.Models.Dodi_nilai_akhir> Dodi_nilai_akhir { get; set; }

       
    }
}