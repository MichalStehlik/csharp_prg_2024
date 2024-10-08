﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cs04_fluentEfc.Data;

#nullable disable

namespace cs04_fluentEfc.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240926075121_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cs04_fluentEfc.Models.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecordId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecordId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("UserId");

                    b.ToTable("Records");

                    b.HasData(
                        new
                        {
                            RecordId = 1,
                            CreatedAt = new DateTime(2024, 9, 26, 9, 51, 21, 156, DateTimeKind.Local).AddTicks(2251),
                            CreatorId = new Guid("209f979c-9737-404d-9b28-4cc8dbab3474"),
                            Description = "Task 1",
                            UserId = new Guid("2a6f961b-6489-4be3-8af3-2950cd730540")
                        },
                        new
                        {
                            RecordId = 2,
                            CreatedAt = new DateTime(2024, 9, 26, 9, 51, 21, 156, DateTimeKind.Local).AddTicks(2309),
                            CreatorId = new Guid("2a6f961b-6489-4be3-8af3-2950cd730540"),
                            Description = "Task 2",
                            UserId = new Guid("209f979c-9737-404d-9b28-4cc8dbab3474")
                        });
                });

            modelBuilder.Entity("cs04_fluentEfc.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("209f979c-9737-404d-9b28-4cc8dbab3474"),
                            Firstname = "John",
                            Lastname = "Doe"
                        },
                        new
                        {
                            UserId = new Guid("2a6f961b-6489-4be3-8af3-2950cd730540"),
                            Firstname = "Jane",
                            Lastname = "Doe"
                        },
                        new
                        {
                            UserId = new Guid("14daecb3-c630-4cae-bf5f-d226bc9f3f53"),
                            Firstname = "Alice",
                            Lastname = "Smith"
                        },
                        new
                        {
                            UserId = new Guid("7e5b83f5-1dc1-49ae-8db3-4412433a7eff"),
                            Firstname = "Bob",
                            Lastname = "Smith"
                        });
                });

            modelBuilder.Entity("cs04_fluentEfc.Models.Record", b =>
                {
                    b.HasOne("cs04_fluentEfc.Models.User", "Creator")
                        .WithMany("CreatedRecords")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("cs04_fluentEfc.Models.User", "User")
                        .WithMany("AssignedRecords")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("User");
                });

            modelBuilder.Entity("cs04_fluentEfc.Models.User", b =>
                {
                    b.Navigation("AssignedRecords");

                    b.Navigation("CreatedRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
