﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using directores.DBContexts;

#nullable disable

namespace directores.Migrations
{
    [DbContext(typeof(DirectoresContext))]
    [Migration("20230109182032_seedData1")]
    partial class seedData1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("directores.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Directores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Maffia movies",
                            Name = "Martin Scorsese"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Adaptation movies",
                            Name = "Stanley Kubrick"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Suspense movies",
                            Name = "Alfred Hitchcock"
                        });
                });

            modelBuilder.Entity("directores.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("DirectorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Maffia Code's movie",
                            DirectorId = 1,
                            Location = "Pittsburgh",
                            Name = "Goodfellas",
                            Year = 1990
                        },
                        new
                        {
                            Id = 2,
                            Description = "Maffia and gambling movie",
                            DirectorId = 1,
                            Location = "Las vegas",
                            Name = "Casino",
                            Year = 1995
                        },
                        new
                        {
                            Id = 3,
                            Description = "Distopic movie",
                            DirectorId = 2,
                            Location = "United Kingdom",
                            Name = "A clockwork orange",
                            Year = 1971
                        },
                        new
                        {
                            Id = 4,
                            Description = "Psicological horror movie",
                            DirectorId = 2,
                            Location = "Overlock Hotel",
                            Name = "The shining",
                            Year = 1980
                        },
                        new
                        {
                            Id = 5,
                            Description = "Mental ilness movie, split personality",
                            DirectorId = 3,
                            Location = "California",
                            Name = "Psycho",
                            Year = 1960
                        },
                        new
                        {
                            Id = 6,
                            Description = "Spy movie",
                            DirectorId = 3,
                            Location = "New York",
                            Name = "Notorious",
                            Year = 1946
                        });
                });

            modelBuilder.Entity("directores.Entities.Movie", b =>
                {
                    b.HasOne("directores.Entities.Director", "Director")
                        .WithMany("Movies")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("directores.Entities.Director", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
