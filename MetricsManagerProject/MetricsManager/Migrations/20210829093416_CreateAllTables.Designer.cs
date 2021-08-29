﻿// <auto-generated />
using System;
using MetricsManager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MetricsManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210829093416_CreateAllTables")]
    partial class CreateAllTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("MetricsManager.Models.Entities.AvailableMemoryMetric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AvailableMBytes")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MemoryMetrics");
                });

            modelBuilder.Entity("MetricsManager.Models.Entities.CpuMetric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProcessorTimeTotal")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CpuMetrics");
                });

            modelBuilder.Entity("MetricsManager.Models.Entities.NetworkMetric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BytesPerSec")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NetworkMetrics");
                });

            modelBuilder.Entity("MetricsManager.Models.Entities.PhysicalDiskMetric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdleTimeTotal")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DiskMetrics");
                });
#pragma warning restore 612, 618
        }
    }
}
