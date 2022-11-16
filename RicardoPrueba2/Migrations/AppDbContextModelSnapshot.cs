﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RicardoPrueba2.Models;

#nullable disable

namespace RicardoPrueba2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RicardoPrueba2.Models.Colaborador", b =>
                {
                    b.Property<string>("Rut")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comuna")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContratoIndefinido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaContratacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Rut");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("RicardoPrueba2.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartamentoId"));

                    b.Property<string>("AreaDepartamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreDepartamento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("RicardoPrueba2.Models.Colaborador", b =>
                {
                    b.HasOne("RicardoPrueba2.Models.Departamento", "Departamento")
                        .WithMany("Colaboradores")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("RicardoPrueba2.Models.Departamento", b =>
                {
                    b.Navigation("Colaboradores");
                });
#pragma warning restore 612, 618
        }
    }
}
