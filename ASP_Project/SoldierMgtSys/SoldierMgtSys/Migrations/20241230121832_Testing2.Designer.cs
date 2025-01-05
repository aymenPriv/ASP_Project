﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoldierMgtSys.Data;

#nullable disable

namespace SoldierMgtSys.Migrations
{
    [DbContext(typeof(WebAppDbContext))]
    [Migration("20241230121832_Testing2")]
    partial class Testing2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoldierMgtSys.Models.Assignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentId"));

                    b.Property<string>("AssignmentDetails")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoldierId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("AssignmentId");

                    b.HasIndex("SoldierId");

                    b.ToTable("TblAssignments");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Deployment", b =>
                {
                    b.Property<int>("DeploymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeploymentId"));

                    b.Property<DateTime>("DeploymentEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeploymentLocation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DeploymentStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoldierId")
                        .HasColumnType("int");

                    b.HasKey("DeploymentId");

                    b.HasIndex("SoldierId");

                    b.ToTable("TblDeployments");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Rank", b =>
                {
                    b.Property<int>("RankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RankId"));

                    b.Property<string>("RankName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RankId");

                    b.ToTable("TblRanks");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Soldier", b =>
                {
                    b.Property<int>("SoldierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoldierId"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfEnlistment")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("SoldierId");

                    b.HasIndex("RankId");

                    b.HasIndex("UnitId");

                    b.ToTable("TblSoldierInfo");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Unit", b =>
                {
                    b.Property<int>("UnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnitId"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UnitName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UnitId");

                    b.ToTable("TblUnits");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Assignment", b =>
                {
                    b.HasOne("SoldierMgtSys.Models.Soldier", "Soldier")
                        .WithMany("Assignments")
                        .HasForeignKey("SoldierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Soldier");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Deployment", b =>
                {
                    b.HasOne("SoldierMgtSys.Models.Soldier", "Soldier")
                        .WithMany()
                        .HasForeignKey("SoldierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Soldier");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Soldier", b =>
                {
                    b.HasOne("SoldierMgtSys.Models.Rank", "Rank")
                        .WithMany("Soldiers")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoldierMgtSys.Models.Unit", "Unit")
                        .WithMany("Soldiers")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rank");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Rank", b =>
                {
                    b.Navigation("Soldiers");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Soldier", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("SoldierMgtSys.Models.Unit", b =>
                {
                    b.Navigation("Soldiers");
                });
#pragma warning restore 612, 618
        }
    }
}
