﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using universe_api.Models;

namespace universeapi.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200106024933_Rerun")]
    partial class Rerun
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("universe_api.Models.SchoolHouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("HouseName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("SchoolHouses");
                });

            modelBuilder.Entity("universe_api.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("PlaysQuidditch")
                        .HasColumnType("boolean");

                    b.Property<int>("SchoolHouseId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SchoolHouseId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("universe_api.Models.Student", b =>
                {
                    b.HasOne("universe_api.Models.SchoolHouse", "SchoolHouse")
                        .WithMany("Students")
                        .HasForeignKey("SchoolHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
