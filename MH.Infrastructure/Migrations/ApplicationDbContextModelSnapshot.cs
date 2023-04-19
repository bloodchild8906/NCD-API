﻿// <auto-generated />
using System;
using MH.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MH.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MH.Domain.DBModel.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasMaxLength(10)
                        .HasColumnType("int");

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

                    b.HasIndex("PositionId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MH.Domain.DBModel.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateOfAppointment")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("MH.Domain.DBModel.ContactDataType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("ContactDataType");
                });

            modelBuilder.Entity("MH.Domain.DBModel.ContactDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContactDataTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("ContactEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("ContactTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactDataTypeId");

                    b.HasIndex("ContactEntityId");

                    b.HasIndex("ContactTypeId");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserProfileId")
                        .IsUnique();

                    b.ToTable("ContactDetails");
                });

            modelBuilder.Entity("MH.Domain.DBModel.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("ContactEntity");
                });

            modelBuilder.Entity("MH.Domain.DBModel.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("ContactType");
                });

            modelBuilder.Entity("MH.Domain.DBModel.MedicalHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("Documents")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Perscription")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RecordedBy")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.HasIndex("RecordedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("MedicalHistory");
                });

            modelBuilder.Entity("MH.Domain.DBModel.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastAppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NextAppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("MH.Domain.DBModel.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("MH.Domain.DBModel.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("MH.Domain.DBModel.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("MH.Domain.DBModel.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("IdNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasDefaultValue("");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("UpdatedBy");

                    b.HasIndex("UserId");

                    b.ToTable("UserProfile");
                });

            modelBuilder.Entity("MH.Domain.DBModel.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("MH.Domain.DBModel.UserStatus", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserStatus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MH.Domain.DBModel.ApplicationUser", b =>
                {
                    b.HasOne("MH.Domain.DBModel.Position", "Position")
                        .WithOne("User")
                        .HasForeignKey("MH.Domain.DBModel.ApplicationUser", "PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Position");
                });

            modelBuilder.Entity("MH.Domain.DBModel.Appointment", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "CreatedByUser")
                        .WithOne("CreatedByAppointment")
                        .HasForeignKey("MH.Domain.DBModel.Appointment", "CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "UpdateByUser")
                        .WithOne("UpdatedByAppointment")
                        .HasForeignKey("MH.Domain.DBModel.Appointment", "UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "User")
                        .WithOne("Appointment")
                        .HasForeignKey("MH.Domain.DBModel.Appointment", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdateByUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MH.Domain.DBModel.ContactDetails", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ContactDataType", "ContactDataType")
                        .WithOne("ContactDetails")
                        .HasForeignKey("MH.Domain.DBModel.ContactDetails", "ContactDataTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ContactEntity", "ContactEntity")
                        .WithOne("ContactDetails")
                        .HasForeignKey("MH.Domain.DBModel.ContactDetails", "ContactEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ContactType", "ContactType")
                        .WithOne("ContactDetails")
                        .HasForeignKey("MH.Domain.DBModel.ContactDetails", "ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "CreatedByUser")
                        .WithOne("CreatedByContactDetails")
                        .HasForeignKey("MH.Domain.DBModel.ContactDetails", "CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "UpdateByUser")
                        .WithOne("UpdatedByContactDetails")
                        .HasForeignKey("MH.Domain.DBModel.ContactDetails", "UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MH.Domain.DBModel.UserProfile", "UserProfile")
                        .WithOne("ContactDetails")
                        .HasForeignKey("MH.Domain.DBModel.ContactDetails", "UserProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactDataType");

                    b.Navigation("ContactEntity");

                    b.Navigation("ContactType");

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdateByUser");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("MH.Domain.DBModel.MedicalHistory", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "CreatedByUser")
                        .WithOne("CreatedByMedicalHistory")
                        .HasForeignKey("MH.Domain.DBModel.MedicalHistory", "CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.Patient", "Patient")
                        .WithOne("MedicalHistory")
                        .HasForeignKey("MH.Domain.DBModel.MedicalHistory", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "RecordedUser")
                        .WithOne("MedicalHistory")
                        .HasForeignKey("MH.Domain.DBModel.MedicalHistory", "RecordedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "UpdateByUser")
                        .WithOne("UpdatedByMedicalHistory")
                        .HasForeignKey("MH.Domain.DBModel.MedicalHistory", "UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("Patient");

                    b.Navigation("RecordedUser");

                    b.Navigation("UpdateByUser");
                });

            modelBuilder.Entity("MH.Domain.DBModel.Patient", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "CreatedByUser")
                        .WithOne("CreatedByPatient")
                        .HasForeignKey("MH.Domain.DBModel.Patient", "CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "UpdateByUser")
                        .WithOne("UpdatedByPatient")
                        .HasForeignKey("MH.Domain.DBModel.Patient", "UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdateByUser");
                });

            modelBuilder.Entity("MH.Domain.DBModel.Permission", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "CreatedByUser")
                        .WithOne("CreatedByPermission")
                        .HasForeignKey("MH.Domain.DBModel.Permission", "CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "UpdateByUser")
                        .WithOne("UpdatedByPermission")
                        .HasForeignKey("MH.Domain.DBModel.Permission", "UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdateByUser");
                });

            modelBuilder.Entity("MH.Domain.DBModel.Position", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "CreatedByUser")
                        .WithOne("CreatedByPosition")
                        .HasForeignKey("MH.Domain.DBModel.Position", "CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "UpdateByUser")
                        .WithOne("UpdatedByPosition")
                        .HasForeignKey("MH.Domain.DBModel.Position", "UpdatedBy")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedByUser");

                    b.Navigation("UpdateByUser");
                });

            modelBuilder.Entity("MH.Domain.DBModel.UserProfile", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("MH.Domain.DBModel.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MH.Domain.DBModel.UserRole", b =>
                {
                    b.HasOne("MH.Domain.DBModel.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MH.Domain.DBModel.UserStatus", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("MH.Domain.DBModel.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", null)
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", null)
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("MH.Domain.DBModel.ApplicationUser", null)
                        .WithMany("Tokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MH.Domain.DBModel.ApplicationUser", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();

                    b.Navigation("Claims");

                    b.Navigation("CreatedByAppointment")
                        .IsRequired();

                    b.Navigation("CreatedByContactDetails")
                        .IsRequired();

                    b.Navigation("CreatedByMedicalHistory")
                        .IsRequired();

                    b.Navigation("CreatedByPatient")
                        .IsRequired();

                    b.Navigation("CreatedByPermission")
                        .IsRequired();

                    b.Navigation("CreatedByPosition")
                        .IsRequired();

                    b.Navigation("Logins");

                    b.Navigation("MedicalHistory")
                        .IsRequired();

                    b.Navigation("Tokens");

                    b.Navigation("UpdatedByAppointment");

                    b.Navigation("UpdatedByContactDetails");

                    b.Navigation("UpdatedByMedicalHistory");

                    b.Navigation("UpdatedByPatient");

                    b.Navigation("UpdatedByPermission");

                    b.Navigation("UpdatedByPosition");

                    b.Navigation("UserProfile")
                        .IsRequired();

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MH.Domain.DBModel.ContactDataType", b =>
                {
                    b.Navigation("ContactDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("MH.Domain.DBModel.ContactEntity", b =>
                {
                    b.Navigation("ContactDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("MH.Domain.DBModel.ContactType", b =>
                {
                    b.Navigation("ContactDetails")
                        .IsRequired();
                });

            modelBuilder.Entity("MH.Domain.DBModel.Patient", b =>
                {
                    b.Navigation("MedicalHistory")
                        .IsRequired();
                });

            modelBuilder.Entity("MH.Domain.DBModel.Position", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("MH.Domain.DBModel.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("MH.Domain.DBModel.UserProfile", b =>
                {
                    b.Navigation("ContactDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
