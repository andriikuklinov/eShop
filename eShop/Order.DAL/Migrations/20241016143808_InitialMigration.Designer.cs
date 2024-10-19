﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Order.DAL.DataContext;

#nullable disable

namespace Order.DAL.Migrations
{
    [DbContext(typeof(OrderDataContext))]
    [Migration("20241016143808_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Order.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderTime = new DateTime(2024, 10, 16, 17, 38, 8, 334, DateTimeKind.Local).AddTicks(378),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderTime = new DateTime(2024, 10, 16, 17, 38, 8, 334, DateTimeKind.Local).AddTicks(415),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            OrderTime = new DateTime(2024, 10, 16, 17, 38, 8, 334, DateTimeKind.Local).AddTicks(418),
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            OrderTime = new DateTime(2024, 10, 16, 17, 38, 8, 334, DateTimeKind.Local).AddTicks(419),
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            OrderTime = new DateTime(2024, 10, 16, 17, 38, 8, 334, DateTimeKind.Local).AddTicks(421),
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Order.DAL.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 2,
                            ProductId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 3,
                            ProductId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 4,
                            ProductId = 1,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 5,
                            OrderId = 4,
                            ProductId = 1,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("Order.DAL.Entities.OrderItem", b =>
                {
                    b.HasOne("Order.DAL.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Order.DAL.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
