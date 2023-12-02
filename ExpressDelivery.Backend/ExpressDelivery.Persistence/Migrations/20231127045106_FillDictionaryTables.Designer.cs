﻿// <auto-generated />
using System;
using ExpressDelivery.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExpressDelivery.Persistence.Migrations
{
    [DbContext(typeof(ExpressDeliveryDbContext))]
    [Migration("20231127045106_FillDictionaryTables")]
    partial class FillDictionaryTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("ExpressDelivery.Domain.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<int>("CargoTypeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("CargoType_Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("TEXT")
                        .HasColumnName("Order_Id");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("CargoTypeId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OrderId");

                    b.ToTable("Cargo", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.CargoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<bool>("IsActual")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsActual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("CargoType", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Executor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<int>("ExecutorStatusId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ExecutorStatus_Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("ExecutorStatusId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("Executor", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.ExecutorStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<bool>("IsActual")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsActual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("ExecutorStatus", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("DeliveryAddress");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("TEXT")
                        .HasColumnName("DeliveryTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<Guid?>("ExecutorId")
                        .HasColumnType("TEXT")
                        .HasColumnName("Executor_Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("OrderStatus_Id");

                    b.Property<string>("ReceiptAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("ReceiptAddress");

                    b.Property<DateTime>("ReceiptTime")
                        .HasColumnType("TEXT")
                        .HasColumnName("ReceiptTime");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT")
                        .HasColumnName("User_Id");

                    b.HasKey("Id");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("UserId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.OrderHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<int>("OrderHistoryMethodId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("OrderHistoryMethod_Id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT")
                        .HasColumnName("Order_Id");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("OrderHistoryMethodId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderHistory", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.OrderHistoryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<bool>("IsActual")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsActual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("OrderHistoryMethod", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT")
                        .HasColumnName("Code");

                    b.Property<bool>("IsActual")
                        .HasColumnType("INTEGER")
                        .HasColumnName("IsActual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("OrderStatus", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("Name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("TS")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Cargo", b =>
                {
                    b.HasOne("ExpressDelivery.Domain.CargoType", "CargoType")
                        .WithMany()
                        .HasForeignKey("CargoTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpressDelivery.Domain.Order", "Order")
                        .WithMany("Cargos")
                        .HasForeignKey("OrderId");

                    b.Navigation("CargoType");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Executor", b =>
                {
                    b.HasOne("ExpressDelivery.Domain.ExecutorStatus", "ExecutorStatus")
                        .WithMany()
                        .HasForeignKey("ExecutorStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExecutorStatus");
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Order", b =>
                {
                    b.HasOne("ExpressDelivery.Domain.Executor", "Executor")
                        .WithMany("Orders")
                        .HasForeignKey("ExecutorId");

                    b.HasOne("ExpressDelivery.Domain.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpressDelivery.Domain.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Executor");

                    b.Navigation("OrderStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExpressDelivery.Domain.OrderHistory", b =>
                {
                    b.HasOne("ExpressDelivery.Domain.OrderHistoryMethod", "OrderHistoryMethod")
                        .WithMany()
                        .HasForeignKey("OrderHistoryMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExpressDelivery.Domain.Order", "Order")
                        .WithMany("OrderHistories")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("OrderHistoryMethod");
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Executor", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Order", b =>
                {
                    b.Navigation("Cargos");

                    b.Navigation("OrderHistories");
                });

            modelBuilder.Entity("ExpressDelivery.Domain.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}