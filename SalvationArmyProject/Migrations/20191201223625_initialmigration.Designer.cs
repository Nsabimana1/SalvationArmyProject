﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalvationArmyProject.Entities;

namespace SalvationArmyProject.Migrations
{
    [DbContext(typeof(DBcontext))]
    [Migration("20191201223625_initialmigration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

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
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

            modelBuilder.Entity("SalvationArmyProject.Entities.Event", b =>
                {
                    b.Property<Guid>("eventId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("eventDateTime");

                    b.Property<string>("eventDescription");

                    b.Property<int>("eventDuration");

                    b.Property<string>("eventName");

                    b.HasKey("eventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("SalvationArmyProject.Entities.EventRequest", b =>
                {
                    b.Property<Guid>("eventRequestId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("eventDescription");

                    b.Property<Guid>("eventFK");

                    b.Property<Guid?>("eventReponseeventResponseId");

                    b.Property<DateTime>("eventRequestDate");

                    b.Property<Guid>("eventRequesterId");

                    b.HasKey("eventRequestId");

                    b.HasIndex("eventFK");

                    b.HasIndex("eventReponseeventResponseId");

                    b.ToTable("EventRequests");
                });

            modelBuilder.Entity("SalvationArmyProject.Entities.EventResponse", b =>
                {
                    b.Property<Guid>("eventResponseId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("eventRequestFK");

                    b.Property<string>("eventResponseComent");

                    b.Property<DateTime>("eventResponseTime");

                    b.Property<bool>("responseStatus");

                    b.HasKey("eventResponseId");

                    b.HasIndex("eventRequestFK");

                    b.ToTable("EventResponses");
                });

            modelBuilder.Entity("SalvationArmyProject.Entities.Feedback", b =>
                {
                    b.Property<Guid>("feedbackId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("Userid");

                    b.Property<Guid>("eventFK");

                    b.Property<Guid?>("eventId");

                    b.Property<string>("feedbackContent");

                    b.Property<Guid>("userFK");

                    b.HasKey("feedbackId");

                    b.HasIndex("Userid");

                    b.HasIndex("eventId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("SalvationArmyProject.Entities.User", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("birthDate");

                    b.Property<string>("email");

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<string>("phoneNumber");

                    b.Property<string>("userPrivilage");

                    b.HasKey("id");

                    b.ToTable("Users");
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

            modelBuilder.Entity("SalvationArmyProject.Entities.EventRequest", b =>
                {
                    b.HasOne("SalvationArmyProject.Entities.Event", "Event")
                        .WithMany("eventRequests")
                        .HasForeignKey("eventFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SalvationArmyProject.Entities.EventResponse", "eventReponse")
                        .WithMany()
                        .HasForeignKey("eventReponseeventResponseId");
                });

            modelBuilder.Entity("SalvationArmyProject.Entities.EventResponse", b =>
                {
                    b.HasOne("SalvationArmyProject.Entities.Event", "EventRequest")
                        .WithMany()
                        .HasForeignKey("eventRequestFK")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SalvationArmyProject.Entities.Feedback", b =>
                {
                    b.HasOne("SalvationArmyProject.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("Userid");

                    b.HasOne("SalvationArmyProject.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("eventId");
                });
#pragma warning restore 612, 618
        }
    }
}