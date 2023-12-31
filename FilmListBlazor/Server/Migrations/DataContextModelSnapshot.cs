﻿// <auto-generated />
using FilmListBlazor.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FilmListBlazor.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FilmListBlazor.Shared.FilmList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DurationTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HappinessScale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WatchId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WatchId");

                    b.ToTable("FilmList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DurationTime = "22 min",
                            Gender = "Drama Psicológico",
                            HappinessScale = "10",
                            Title = "How I Met Your Mother",
                            Type = "Série",
                            WatchId = 1
                        },
                        new
                        {
                            Id = 2,
                            DurationTime = "115 min",
                            Gender = "Drama Psicológico",
                            HappinessScale = "10",
                            Title = "A Baleia",
                            Type = "Filme",
                            WatchId = 2
                        });
                });

            modelBuilder.Entity("FilmListBlazor.Shared.Watch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Watch");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sim"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Não"
                        });
                });

            modelBuilder.Entity("FilmListBlazor.Shared.FilmList", b =>
                {
                    b.HasOne("FilmListBlazor.Shared.Watch", "Watch")
                        .WithMany()
                        .HasForeignKey("WatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Watch");
                });
#pragma warning restore 612, 618
        }
    }
}
