﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using New.Data;

namespace New.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190716104008_perubahanapplicationuser")]
    partial class perubahanapplicationuser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("New.Models.Diary", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Aktifitas")
                        .IsRequired()
                        .HasMaxLength(254)
                        .IsUnicode(false);

                    b.Property<string>("Hasil")
                        .IsRequired()
                        .HasMaxLength(254)
                        .IsUnicode(false);

                    b.Property<string>("IdPeriode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("Nip")
                        .IsRequired()
                        .HasMaxLength(18)
                        .IsUnicode(false);

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("date");

                    b.Property<string>("Tempat")
                        .IsRequired()
                        .HasMaxLength(254)
                        .IsUnicode(false);

                    b.Property<TimeSpan>("WaktuHingga");

                    b.Property<TimeSpan>("WaktuMulai");

                    b.Property<int>("WaktuSetuju1");

                    b.Property<int>("WaktuSetuju2");

                    b.HasKey("Id");

                    b.HasIndex("IdPeriode", "Nip");

                    b.ToTable("Diary");
                });

            modelBuilder.Entity("New.Models.HariKerja", b =>
                {
                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("date");

                    b.Property<int>("IdLibur");

                    b.HasKey("Tanggal");

                    b.HasIndex("IdLibur");

                    b.ToTable("HariKerja");
                });

            modelBuilder.Entity("New.Models.HariKerjaNip", b =>
                {
                    b.Property<string>("IdPeriode")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("NIP")
                        .HasMaxLength(18)
                        .IsUnicode(false);

                    b.Property<DateTime>("Tanggal")
                        .HasColumnType("date");

                    b.Property<int>("IdHariKerjaStatus");

                    b.HasKey("IdPeriode", "NIP", "Tanggal");

                    b.HasIndex("IdHariKerjaStatus");

                    b.ToTable("HariKerjaNip");
                });

            modelBuilder.Entity("New.Models.HariKerjaStatus", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("Libur");

                    b.Property<string>("Uraian")
                        .IsRequired()
                        .HasMaxLength(254)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("HariKerjaStatus");
                });

            modelBuilder.Entity("New.Models.Jabatan", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("IdAtas");

                    b.Property<int>("IdEselon");

                    b.Property<int>("IdJabatan");

                    b.Property<int>("IdUnitKerja");

                    b.Property<string>("Uraian")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<int>("Urut");

                    b.HasKey("Id");

                    b.HasIndex("IdUnitKerja");

                    b.ToTable("Jabatan");
                });

            modelBuilder.Entity("New.Models.JamKerjaPola", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int?>("Jum");

                    b.Property<int?>("Jumlah");

                    b.Property<int?>("Kam");

                    b.Property<TimeSpan>("KeluarA");

                    b.Property<TimeSpan>("KeluarB");

                    b.Property<TimeSpan?>("MasukA");

                    b.Property<TimeSpan>("MasukB");

                    b.Property<int?>("Mgg");

                    b.Property<int?>("Rab");

                    b.Property<int?>("Sab");

                    b.Property<int?>("Sel");

                    b.Property<int?>("Sen");

                    b.Property<string>("Uraian")
                        .IsRequired()
                        .HasMaxLength(254)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("JamKerjaPola");
                });

            modelBuilder.Entity("New.Models.Pegawai", b =>
                {
                    b.Property<string>("NIP")
                        .HasMaxLength(18)
                        .IsUnicode(false);

                    b.Property<string>("GelarBelakang")
                        .HasMaxLength(25)
                        .IsUnicode(false);

                    b.Property<string>("GelarDepan")
                        .HasMaxLength(8)
                        .IsUnicode(false);

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("TempatLahir")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<DateTime?>("TgLLahir")
                        .HasColumnType("date");

                    b.Property<DateTime?>("TglPensiun")
                        .HasColumnType("date");

                    b.HasKey("NIP");

                    b.ToTable("Pegawai");
                });

            modelBuilder.Entity("New.Models.Periode", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<int?>("Bulan");

                    b.Property<int?>("Tahun");

                    b.HasKey("Id");

                    b.ToTable("Periode");
                });

            modelBuilder.Entity("New.Models.PeriodeKaSKPD", b =>
                {
                    b.Property<string>("IdPeriode")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<int>("IdUnitKerja");

                    b.Property<int>("IdJabatan");

                    b.Property<string>("IdKaSKPD")
                        .IsRequired()
                        .HasMaxLength(18)
                        .IsUnicode(false);

                    b.HasKey("IdPeriode", "IdUnitKerja");

                    b.HasIndex("IdJabatan");

                    b.HasIndex("IdKaSKPD");

                    b.ToTable("PeriodeKaSKPD");
                });

            modelBuilder.Entity("New.Models.PeriodeNIP", b =>
                {
                    b.Property<string>("IdPeriode")
                        .HasMaxLength(7)
                        .IsUnicode(false);

                    b.Property<string>("Nip")
                        .HasMaxLength(18)
                        .IsUnicode(false);

                    b.Property<int>("IdJabatan");

                    b.Property<int>("IdJabatanAtas1");

                    b.Property<int>("IdJabatanAtas2");

                    b.Property<int>("IdJamKerjaPola");

                    b.Property<int>("IdUnitKerja");

                    b.Property<string>("NipAtas1")
                        .IsRequired()
                        .HasMaxLength(18)
                        .IsUnicode(false);

                    b.Property<string>("NipAtas2")
                        .IsRequired()
                        .HasMaxLength(18)
                        .IsUnicode(false);

                    b.HasKey("IdPeriode", "Nip");

                    b.HasIndex("IdJabatan");

                    b.HasIndex("IdJabatanAtas1");

                    b.HasIndex("IdJabatanAtas2");

                    b.HasIndex("IdJamKerjaPola");

                    b.HasIndex("IdUnitKerja");

                    b.HasIndex("Nip");

                    b.HasIndex("NipAtas1");

                    b.HasIndex("NipAtas2");

                    b.HasIndex("IdPeriode", "IdUnitKerja");

                    b.ToTable("PeriodeNIP");
                });

            modelBuilder.Entity("New.Models.UnitKerja", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("IdLevel");

                    b.Property<string>("Uraian")
                        .IsRequired()
                        .HasColumnName("Uraian")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("UnitKerja");
                });

            modelBuilder.Entity("New.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("NIP");

                    b.Property<string>("Nama");

                    b.Property<short>("UnitKerja");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("New.Models.Diary", b =>
                {
                    b.HasOne("New.Models.PeriodeNIP", "PeriodeNIP")
                        .WithMany("Diary")
                        .HasForeignKey("IdPeriode", "Nip")
                        .HasConstraintName("FK_Diary_PeriodeNIP");
                });

            modelBuilder.Entity("New.Models.HariKerja", b =>
                {
                    b.HasOne("New.Models.HariKerjaStatus", "IdLiburNavigation")
                        .WithMany("HariKerja")
                        .HasForeignKey("IdLibur")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("New.Models.HariKerjaNip", b =>
                {
                    b.HasOne("New.Models.HariKerjaStatus", "IdHariKerjaStatusNavigation")
                        .WithMany("HariKerjaNip")
                        .HasForeignKey("IdHariKerjaStatus")
                        .HasConstraintName("FK_HariKerjaNip_HariKerjaStatus");

                    b.HasOne("New.Models.PeriodeNIP", "PeriodeNIP")
                        .WithMany("HariKerjaNip")
                        .HasForeignKey("IdPeriode", "NIP")
                        .HasConstraintName("FK_HariKerjaNip_PeriodeNIP");
                });

            modelBuilder.Entity("New.Models.Jabatan", b =>
                {
                    b.HasOne("New.Models.UnitKerja", "IdUnitKerjaNavigation")
                        .WithMany("Jabatan")
                        .HasForeignKey("IdUnitKerja")
                        .HasConstraintName("FK_Jabatan_UnitKerja");
                });

            modelBuilder.Entity("New.Models.PeriodeKaSKPD", b =>
                {
                    b.HasOne("New.Models.Jabatan", "IdJabatanNavigation")
                        .WithMany("PeriodeKaSKPD")
                        .HasForeignKey("IdJabatan")
                        .HasConstraintName("FK_PeriodeKaSKPD_Jabatan");

                    b.HasOne("New.Models.Pegawai", "IdKaSKPDNavigation")
                        .WithMany("PeriodeKaSKPD")
                        .HasForeignKey("IdKaSKPD")
                        .HasConstraintName("FK_PeriodeKaSKPD_Pegawai");
                });

            modelBuilder.Entity("New.Models.PeriodeNIP", b =>
                {
                    b.HasOne("New.Models.Jabatan", "IdJabatanNavigation")
                        .WithMany("PeriodeNIPIdJabatanNavigation")
                        .HasForeignKey("IdJabatan")
                        .HasConstraintName("FK_PeriodeNIP_Jabatan");

                    b.HasOne("New.Models.Jabatan", "IdJabatanAtas1Navigation")
                        .WithMany("PeriodeNIPIdJabatanAtas1Navigation")
                        .HasForeignKey("IdJabatanAtas1")
                        .HasConstraintName("FK_PeriodeNIP_Jabatan1");

                    b.HasOne("New.Models.Jabatan", "IdJabatanAtas2Navigation")
                        .WithMany("PeriodeNIPIdJabatanAtas2Navigation")
                        .HasForeignKey("IdJabatanAtas2")
                        .HasConstraintName("FK_PeriodeNIP_Jabatan2");

                    b.HasOne("New.Models.JamKerjaPola", "IdJamKerjaPolaNavigation")
                        .WithMany("PeriodeNIP")
                        .HasForeignKey("IdJamKerjaPola")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("New.Models.Periode", "IdPeriodeNavigation")
                        .WithMany("PeriodeNIP")
                        .HasForeignKey("IdPeriode")
                        .HasConstraintName("FK_PeriodeNIP_Periode");

                    b.HasOne("New.Models.UnitKerja", "IdUnitKerjaNavigation")
                        .WithMany("PeriodeNIP")
                        .HasForeignKey("IdUnitKerja")
                        .HasConstraintName("FK_PeriodeNIP_UnitKerja");

                    b.HasOne("New.Models.Pegawai", "NipNavigation")
                        .WithMany("PeriodeNIPNipNavigation")
                        .HasForeignKey("Nip")
                        .HasConstraintName("FK_PeriodeNIP_Pegawai");

                    b.HasOne("New.Models.Pegawai", "NipAtas1Navigation")
                        .WithMany("PeriodeNIPNipAtas1Navigation")
                        .HasForeignKey("NipAtas1")
                        .HasConstraintName("FK_PeriodeNIP_Pegawai1");

                    b.HasOne("New.Models.Pegawai", "NipAtas2Navigation")
                        .WithMany("PeriodeNIPNipAtas2Navigation")
                        .HasForeignKey("NipAtas2")
                        .HasConstraintName("FK_PeriodeNIP_Pegawai2");

                    b.HasOne("New.Models.PeriodeKaSKPD", "Id")
                        .WithMany("PeriodeNIP")
                        .HasForeignKey("IdPeriode", "IdUnitKerja")
                        .HasConstraintName("FK_PeriodeNIP_PeriodeKaSKPD");
                });
#pragma warning restore 612, 618
        }
    }
}
