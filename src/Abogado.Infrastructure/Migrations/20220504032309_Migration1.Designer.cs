﻿// <auto-generated />
using System;
using Abogado.Infrastructure.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Abogado.Infrastructure.Migrations
{
    [DbContext(typeof(AbogadoContext))]
    [Migration("20220504032309_Migration1")]
    partial class Migration1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Abogado.Domain.Entities.Caso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormaDivorcio")
                        .HasColumnType("int");

                    b.Property<string>("NombreCaso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Proceso")
                        .HasColumnType("int");

                    b.Property<string>("RutaArchivo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("mecanismoDisolucion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Casos");
                });

            modelBuilder.Entity("Abogado.Domain.Entities.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("Abogado.Domain.Entities.HistoricoCaso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CasoId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormaDivorcio")
                        .HasColumnType("int");

                    b.Property<string>("NombreCaso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Proceso")
                        .HasColumnType("int");

                    b.Property<int>("mecanismoDisolucion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CasoId");

                    b.ToTable("Historicos");
                });

            modelBuilder.Entity("Abogado.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Abogado.Domain.Entities.Caso", b =>
                {
                    b.HasOne("Abogado.Domain.Entities.Usuario", null)
                        .WithMany("Casos")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Abogado.Domain.Entities.Cita", b =>
                {
                    b.HasOne("Abogado.Domain.Entities.Usuario", null)
                        .WithMany("Citas")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("Abogado.Domain.Entities.HistoricoCaso", b =>
                {
                    b.HasOne("Abogado.Domain.Entities.Caso", null)
                        .WithMany("Historicos")
                        .HasForeignKey("CasoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Abogado.Domain.Entities.Caso", b =>
                {
                    b.Navigation("Historicos");
                });

            modelBuilder.Entity("Abogado.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Casos");

                    b.Navigation("Citas");
                });
#pragma warning restore 612, 618
        }
    }
}