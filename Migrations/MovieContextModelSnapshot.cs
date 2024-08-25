﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorMovie.Data;

#nullable disable

namespace RazorMovie.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RazorMovie.Model.HallCinema", b =>
                {
                    b.Property<int>("NumberHall")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumberHall"));

                    b.Property<int>("CountRows")
                        .HasColumnType("int");

                    b.Property<int>("CountSeats")
                        .HasColumnType("int");

                    b.HasKey("NumberHall");

                    b.ToTable("HallCinemas");
                });

            modelBuilder.Entity("RazorMovie.Model.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("RazorMovie.Model.Shedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndFilm")
                        .HasColumnType("datetime2");

                    b.Property<int>("HallCinemaNumberHall")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartFilm")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HallCinemaNumberHall");

                    b.HasIndex("MovieId");

                    b.ToTable("Shedules");
                });

            modelBuilder.Entity("RazorMovie.Model.Shedule", b =>
                {
                    b.HasOne("RazorMovie.Model.HallCinema", "HallCinema")
                        .WithMany()
                        .HasForeignKey("HallCinemaNumberHall")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RazorMovie.Model.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HallCinema");

                    b.Navigation("Movie");
                });
#pragma warning restore 612, 618
        }
    }
}
