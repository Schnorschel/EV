﻿// <auto-generated />
using EV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EV.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200103184652_AddFirstTablesViews")]
    partial class AddFirstTablesViews
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EV.Models.EVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("BatteryCapacity")
                        .HasColumnType("double precision");

                    b.Property<int>("EvTypeId")
                        .HasColumnType("integer");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EvTypeId");

                    b.ToTable("EVehicles");
                });

            modelBuilder.Entity("EV.Models.EvType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("EvTypeAbbr")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EvTypeLongDescription")
                        .HasColumnType("text");

                    b.Property<string>("EvTypeShortDescription")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EvTypes");
                });

            modelBuilder.Entity("EV.Models.EVehicle", b =>
                {
                    b.HasOne("EV.Models.EvType", "EvType")
                        .WithMany("EVehicles")
                        .HasForeignKey("EvTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
