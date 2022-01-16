﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherStationServer.DataAccess;

namespace WeatherStationServer.Migrations
{
    [DbContext(typeof(WeatherStationDbContext))]
    partial class WeatherStationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherStationServer.DataAccess.Entities.OutdoorWeatherReportEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("HumidityInside")
                        .HasColumnType("int");

                    b.Property<int>("HumidityOutside")
                        .HasColumnType("int");

                    b.Property<int>("PM1_0")
                        .HasColumnType("int");

                    b.Property<int>("PM2_5")
                        .HasColumnType("int");

                    b.Property<int>("PM_10_0")
                        .HasColumnType("int");

                    b.Property<decimal>("PressureOutside")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("RestartsCount")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TemperatureInside")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TemperatureOutside")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("TimeStampOfFinish")
                        .HasColumnType("bigint");

                    b.Property<long>("TimeStampOfStart")
                        .HasColumnType("bigint");

                    b.Property<int>("WifiErrors")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OutdoorWeatherReports");
                });
#pragma warning restore 612, 618
        }
    }
}
