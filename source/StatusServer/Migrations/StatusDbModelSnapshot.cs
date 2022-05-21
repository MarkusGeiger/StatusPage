﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace StatusServer.Migrations
{
    [DbContext(typeof(StatusDb))]
    partial class StatusDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("StatusConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("StatusItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StatusItems");
                });

            modelBuilder.Entity("StatusTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StatusConfigId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StatusItemId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("StatusConfigId");

                    b.HasIndex("StatusItemId");

                    b.ToTable("StatusTask");
                });

            modelBuilder.Entity("StatusTask", b =>
                {
                    b.HasOne("StatusConfig", null)
                        .WithMany("TaskConfigurations")
                        .HasForeignKey("StatusConfigId");

                    b.HasOne("StatusItem", null)
                        .WithMany("StatusTasks")
                        .HasForeignKey("StatusItemId");
                });

            modelBuilder.Entity("StatusConfig", b =>
                {
                    b.Navigation("TaskConfigurations");
                });

            modelBuilder.Entity("StatusItem", b =>
                {
                    b.Navigation("StatusTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
