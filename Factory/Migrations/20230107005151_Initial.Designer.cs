﻿// <auto-generated />
using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Factory.Migrations
{
    [DbContext(typeof(FactoryContext))]
    [Migration("20230107005151_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("MechanicId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("MachineId");

                    b.HasIndex("MechanicId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Factory.Models.Mechanic", b =>
                {
                    b.Property<int>("MechanicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("MechanicId");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.HasOne("Factory.Models.Mechanic", "Mechanic")
                        .WithMany("Machines")
                        .HasForeignKey("MechanicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mechanic");
                });

            modelBuilder.Entity("Factory.Models.Mechanic", b =>
                {
                    b.Navigation("Machines");
                });
#pragma warning restore 612, 618
        }
    }
}
