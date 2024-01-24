﻿// <auto-generated />
using System;
using DAW_Exam.Server.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAWExam.Server.Migrations
{
    [DbContext(typeof(DawContext))]
    [Migration("20240123220507_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DAW_Exam.Server.Entities.Excavator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ExcavatorTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .HasColumnType("longtext");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.Property<int?>("YearOfFabrication")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcavatorTypeId");

                    b.ToTable("Excavators");
                });

            modelBuilder.Entity("DAW_Exam.Server.Entities.ExcavatorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ExcavatorTypes");
                });

            modelBuilder.Entity("DAW_Exam.Server.Entities.Excavator", b =>
                {
                    b.HasOne("DAW_Exam.Server.Entities.ExcavatorType", "ExcavatorType")
                        .WithMany("Excavators")
                        .HasForeignKey("ExcavatorTypeId");

                    b.Navigation("ExcavatorType");
                });

            modelBuilder.Entity("DAW_Exam.Server.Entities.ExcavatorType", b =>
                {
                    b.Navigation("Excavators");
                });
#pragma warning restore 612, 618
        }
    }
}