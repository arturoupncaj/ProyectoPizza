﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzeriaWeb3._1.Data;

#nullable disable

namespace PizzeriaWeb3._1.Migrations
{
    [DbContext(typeof(PizzeriaContext))]
    [Migration("20240915160926_migracion2")]
    partial class migracion2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Mesas", b =>
                {
                    b.Property<int>("IdMesas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMesas"));

                    b.Property<string>("NombreMesas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("IdMesas");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.PedidoProducto", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdPedidoProducto")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("PedidoId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("PedidoProductos");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Pedidos", b =>
                {
                    b.Property<int>("IdPedidos")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedidos"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("IdPedidos");

                    b.HasIndex("MesaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Productos", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioProducto")
                        .HasColumnType("float");

                    b.Property<int>("StockProducto")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("IdProducto");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Mesas", b =>
                {
                    b.HasOne("PizzeriaWeb3._1.Models.Usuarios", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.PedidoProducto", b =>
                {
                    b.HasOne("PizzeriaWeb3._1.Models.Pedidos", "Pedido")
                        .WithMany("PedidoProductos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PizzeriaWeb3._1.Models.Productos", "Producto")
                        .WithMany("PedidoProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Pedidos", b =>
                {
                    b.HasOne("PizzeriaWeb3._1.Models.Mesas", "Mesa")
                        .WithMany("Pedidos")
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PizzeriaWeb3._1.Models.Usuarios", "Usuario")
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Mesa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Productos", b =>
                {
                    b.HasOne("PizzeriaWeb3._1.Models.Usuarios", "Usuario")
                        .WithMany("Productos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Usuarios", b =>
                {
                    b.HasOne("PizzeriaWeb3._1.Models.Roles", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Mesas", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Pedidos", b =>
                {
                    b.Navigation("PedidoProductos");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Productos", b =>
                {
                    b.Navigation("PedidoProductos");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Roles", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("PizzeriaWeb3._1.Models.Usuarios", b =>
                {
                    b.Navigation("Pedidos");

                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
