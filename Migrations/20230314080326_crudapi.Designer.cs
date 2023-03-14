﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using crudapi.DBContext;

#nullable disable

namespace crudapi.Migrations
{
    [DbContext(typeof(CRUDDbContext))]
    [Migration("20230314080326_crudapi")]
    partial class crudapi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("crudapi.Model.RegionTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Population")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("crudapi.Model.WalksDifficultyTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WalksDifficulty");
                });

            modelBuilder.Entity("crudapi.Model.WalksTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("WalksDifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.HasIndex("WalksDifficultyId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("crudapi.Model.WalksTable", b =>
                {
                    b.HasOne("crudapi.Model.RegionTable", "Region")
                        .WithMany("Walks")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("crudapi.Model.WalksDifficultyTable", "WalksDifficulty")
                        .WithMany()
                        .HasForeignKey("WalksDifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("WalksDifficulty");
                });

            modelBuilder.Entity("crudapi.Model.RegionTable", b =>
                {
                    b.Navigation("Walks");
                });
#pragma warning restore 612, 618
        }
    }
}