﻿// <auto-generated />
using System;
using HomeService.Infrastructure.DB.SqlServer.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HomeService.Infrastructure.DB.SqlServer.EFCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240709000330_edit")]
    partial class edit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentStatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId");

                    b.HasIndex("PaymentStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.InvoiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentStatusId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceRequestId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentStatusId");

                    b.HasIndex("ServiceRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PaymentStatuses");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ExpertSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExpertId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("SkillId");

                    b.ToTable("ExpertSkills");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ExpertId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceRequestId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("ServiceRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ServiceCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategories");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.ToTable("ServiceImages");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceRequestStatusId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("ServiceRequestStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("ServiceRequests");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequestImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("ServiceRequestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceRequestId");

                    b.ToTable("ServiceRequestImages");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequestStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ServiceRequestStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Accepted"
                        },
                        new
                        {
                            Id = 3,
                            Name = "InProgress"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Completed"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cancelled"
                        });
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceSugesstion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExpertId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ServiceRequestId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ServiceSugesstionDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ServiceSugesstionPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ExpertId");

                    b.HasIndex("ServiceRequestId");

                    b.ToTable("ServiceSugesstions");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("HomeService.Domain.Core.UserAgg.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HomeService.Domain.Core.UserAgg.Entities.ProfileImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("ProfileImages");
                });

            modelBuilder.Entity("HomeService.Domain.Core.UserAgg.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.Invoice", b =>
                {
                    b.HasOne("HomeService.Domain.Core.PaymentAgg.Entities.Payment", "Payment")
                        .WithMany("Invoices")
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeService.Domain.Core.PaymentAgg.Entities.PaymentStatus", "PaymentStatus")
                        .WithMany("Invoices")
                        .HasForeignKey("PaymentStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", "User")
                        .WithMany("Invoices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Payment");

                    b.Navigation("PaymentStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.InvoiceDetail", b =>
                {
                    b.HasOne("HomeService.Domain.Core.PaymentAgg.Entities.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.Payment", b =>
                {
                    b.HasOne("HomeService.Domain.Core.PaymentAgg.Entities.PaymentStatus", "PaymentStatus")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentStatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequest", "ServiceRequest")
                        .WithMany("Payments")
                        .HasForeignKey("ServiceRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("PaymentStatus");

                    b.Navigation("ServiceRequest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ExpertSkill", b =>
                {
                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", "User")
                        .WithMany("ExpertSkills")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.Skill", "Skill")
                        .WithMany("ExpertSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.Review", b =>
                {
                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", "Expert")
                        .WithMany("ExpertReviews")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.Service", "service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequest", "ServiceRequest")
                        .WithMany("Reviews")
                        .HasForeignKey("ServiceRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Expert");

                    b.Navigation("ServiceRequest");

                    b.Navigation("User");

                    b.Navigation("service");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.Service", b =>
                {
                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.ServiceCategory", "ServiceCategory")
                        .WithMany("Services")
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ServiceCategory");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceImage", b =>
                {
                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.Service", "Service")
                        .WithMany("ServiceImages")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequest", b =>
                {
                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.Service", "Service")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequestStatus", "ServiceRequestStatus")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("ServiceRequestStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", "User")
                        .WithMany("ServiceRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Service");

                    b.Navigation("ServiceRequestStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequestImage", b =>
                {
                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequest", "ServiceRequest")
                        .WithMany("ServiceRequestImages")
                        .HasForeignKey("ServiceRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ServiceRequest");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceSugesstion", b =>
                {
                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", "Expert")
                        .WithMany("ServiceSugesstions")
                        .HasForeignKey("ExpertId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequest", "ServiceRequest")
                        .WithMany("ServiceSugesstions")
                        .HasForeignKey("ServiceRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Expert");

                    b.Navigation("ServiceRequest");
                });

            modelBuilder.Entity("HomeService.Domain.Core.UserAgg.Entities.Address", b =>
                {
                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", "User")
                        .WithMany("Addresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("HomeService.Domain.Core.UserAgg.Entities.ProfileImage", b =>
                {
                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", "User")
                        .WithOne("ProfileImage")
                        .HasForeignKey("HomeService.Domain.Core.UserAgg.Entities.ProfileImage", "UserId");

                    b.Navigation("User");
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
                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", null)
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

                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HomeService.Domain.Core.UserAgg.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.Payment", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("HomeService.Domain.Core.PaymentAgg.Entities.PaymentStatus", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.Service", b =>
                {
                    b.Navigation("ServiceImages");

                    b.Navigation("ServiceRequests");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceCategory", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequest", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Reviews");

                    b.Navigation("ServiceRequestImages");

                    b.Navigation("ServiceSugesstions");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.ServiceRequestStatus", b =>
                {
                    b.Navigation("ServiceRequests");
                });

            modelBuilder.Entity("HomeService.Domain.Core.ServiceAgg.Entities.Skill", b =>
                {
                    b.Navigation("ExpertSkills");
                });

            modelBuilder.Entity("HomeService.Domain.Core.UserAgg.Entities.User", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("ExpertReviews");

                    b.Navigation("ExpertSkills");

                    b.Navigation("Invoices");

                    b.Navigation("Payments");

                    b.Navigation("ProfileImage");

                    b.Navigation("Reviews");

                    b.Navigation("ServiceRequests");

                    b.Navigation("ServiceSugesstions");
                });
#pragma warning restore 612, 618
        }
    }
}
