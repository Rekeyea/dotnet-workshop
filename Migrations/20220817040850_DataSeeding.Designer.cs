﻿// <auto-generated />
using System;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Workshop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220817040850_DataSeeding")]
    partial class DataSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7650),
                            IsDeleted = false,
                            ModifiedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7650),
                            Name = "Emi",
                            Surname = "Con"
                        });
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Value")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ClientId = 1L,
                            CreatedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7310),
                            Description = "Desc Prod 1",
                            IsDeleted = false,
                            ModifiedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7350),
                            Name = "Prod 1",
                            Value = 1000m
                        },
                        new
                        {
                            Id = 2L,
                            ClientId = 1L,
                            CreatedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7360),
                            Description = "Desc Prod 2",
                            IsDeleted = false,
                            ModifiedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7360),
                            Name = "Prod 2",
                            Value = 1300m
                        },
                        new
                        {
                            Id = 3L,
                            ClientId = 1L,
                            CreatedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7360),
                            Description = "Desc Prod 3",
                            IsDeleted = false,
                            ModifiedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7360),
                            Name = "Prod 3",
                            Value = 100m
                        },
                        new
                        {
                            Id = 4L,
                            ClientId = 1L,
                            CreatedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370),
                            Description = "Desc Prod 4",
                            IsDeleted = false,
                            ModifiedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370),
                            Name = "Prod 4",
                            Value = 100.4m
                        },
                        new
                        {
                            Id = 5L,
                            ClientId = 1L,
                            CreatedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370),
                            Description = "Desc Prod 5",
                            IsDeleted = false,
                            ModifiedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370),
                            Name = "Prod 5",
                            Value = 2030.50m
                        },
                        new
                        {
                            Id = 6L,
                            ClientId = 1L,
                            CreatedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370),
                            Description = "Desc Prod 6",
                            IsDeleted = false,
                            ModifiedTime = new DateTime(2022, 8, 17, 4, 8, 50, 802, DateTimeKind.Utc).AddTicks(7370),
                            Name = "Prod 6",
                            Value = 2000m
                        });
                });

            modelBuilder.Entity("Entities.Product", b =>
                {
                    b.HasOne("Entities.Client", null)
                        .WithMany("Products")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Entities.Client", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
