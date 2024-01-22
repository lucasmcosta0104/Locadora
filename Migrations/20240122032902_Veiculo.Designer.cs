﻿// <auto-generated />
using Locadora.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Locadora.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240122032902_Veiculo")]
    partial class Veiculo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Locadora.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Enedereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocadoraModeloId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocadoraModeloId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Locadora.Models.LocadoraModelo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Segmento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocadoraModelo");
                });

            modelBuilder.Entity("Locadora.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Locadora.Models.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponibilidade")
                        .HasColumnType("bit");

                    b.Property<int>("LocadoraModeloId")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorDiaria")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("LocadoraModeloId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("Locadora.Models.Cliente", b =>
                {
                    b.HasOne("Locadora.Models.LocadoraModelo", "LocadoraModelo")
                        .WithMany("Clientes")
                        .HasForeignKey("LocadoraModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocadoraModelo");
                });

            modelBuilder.Entity("Locadora.Models.Veiculo", b =>
                {
                    b.HasOne("Locadora.Models.LocadoraModelo", "LocadoraModelo")
                        .WithMany("Veiculos")
                        .HasForeignKey("LocadoraModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocadoraModelo");
                });

            modelBuilder.Entity("Locadora.Models.LocadoraModelo", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
