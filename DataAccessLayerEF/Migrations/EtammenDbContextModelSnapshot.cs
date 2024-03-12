﻿// <auto-generated />
using System;
using System.Collections.Generic;
using DataAccessLayerEF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayerEF.Migrations
{
    [DbContext(typeof(EtammenDbContext))]
    partial class EtammenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccessLayerEF.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClinicId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<bool>("IsAccepted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAttended")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("ReservtionPeriodNumber")
                        .HasColumnType("int");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClinicId");

                    b.HasIndex("patientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Clinic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeOnly>("ClosingHour")
                        .HasColumnType("time");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DeletionDate")
                        .HasColumnType("date");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("ExmainationDuration")
                        .HasColumnType("time");

                    b.Property<decimal>("Fees")
                        .HasColumnType("money");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OpeningDays")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("OpeningHour")
                        .HasColumnType("time");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "DataAccessLayerEF.Models.Clinic.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("StreetAddress")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("nvarchar(80)");

                            b1.Property<string>("governorate")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("nvarchar(80)");
                        });

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Clinics");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AboutTheDoctor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ActualRting")
                        .HasColumnType("money");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Certificate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("DeletionDate")
                        .HasColumnType("date");

                    b.Property<decimal?>("HomeVisitFees")
                        .HasColumnType("money");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisitHome")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("LastUpdate")
                        .HasColumnType("date");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Speciality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TotalRatings")
                        .HasColumnType("int");

                    b.Property<string>("YearsOfExperience")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.DoctorReviews", b =>
                {
                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.HasKey("PatientId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("DoctorReviews");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateOnly>("CreationDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DeletionDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("LastUpdate")
                        .HasColumnType("date");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "DataAccessLayerEF.Models.Patient.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("StreetAddress")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("nvarchar(80)");

                            b1.Property<string>("governorate")
                                .IsRequired()
                                .HasMaxLength(80)
                                .HasColumnType("nvarchar(80)");
                        });

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique()
                        .HasFilter("[ApplicationUserId] IS NOT NULL");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Appointment", b =>
                {
                    b.HasOne("DataAccessLayerEF.Models.Clinic", "Clinic")
                        .WithMany("Appointments")
                        .HasForeignKey("ClinicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayerEF.Models.Patient", "Patient")
                        .WithMany("Appointments")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinic");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Clinic", b =>
                {
                    b.HasOne("DataAccessLayerEF.Models.Doctor", "Doctor")
                        .WithMany("Clinics")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Doctor", b =>
                {
                    b.HasOne("DataAccessLayerEF.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Doctor")
                        .HasForeignKey("DataAccessLayerEF.Models.Doctor", "ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.DoctorReviews", b =>
                {
                    b.HasOne("DataAccessLayerEF.Models.Doctor", "Doctor")
                        .WithMany("DoctorReviews")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayerEF.Models.Patient", "Patient")
                        .WithMany("DoctorReviews")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Patient", b =>
                {
                    b.HasOne("DataAccessLayerEF.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Patient")
                        .HasForeignKey("DataAccessLayerEF.Models.Patient", "ApplicationUserId");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataAccessLayerEF.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataAccessLayerEF.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayerEF.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataAccessLayerEF.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.ApplicationUser", b =>
                {
                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Clinic", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Doctor", b =>
                {
                    b.Navigation("Clinics");

                    b.Navigation("DoctorReviews");
                });

            modelBuilder.Entity("DataAccessLayerEF.Models.Patient", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("DoctorReviews");
                });
#pragma warning restore 612, 618
        }
    }
}
