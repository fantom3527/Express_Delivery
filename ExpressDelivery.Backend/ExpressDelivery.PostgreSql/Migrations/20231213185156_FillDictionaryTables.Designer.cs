﻿// <auto-generated />
using System;
using ExpressDelivery.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExpressDelivery.PostgreSql.Migrations
{
    [DbContext(typeof(ExpressDeliveryDbContext))]
    [Migration("20231213185156_FillDictionaryTables")]
    partial class FillDictionaryTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExpressDelivery.Domain.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("CargoTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("cargo_type_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id")
                        .HasName("pk_cargo");

                    b.HasIndex("CargoTypeId")
                        .HasDatabaseName("ix_cargo_cargo_type_id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_cargo_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_cargo_order_id");

                    b.ToTable("cargo", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.CargoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("code");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean")
                        .HasColumnName("is_actual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id")
                        .HasName("pk_cargo_type");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_cargo_type_id");

                    b.ToTable("cargo_type", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Executor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<int>("ExecutorStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("executor_status_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id")
                        .HasName("pk_executor");

                    b.HasIndex("ExecutorStatusId")
                        .HasDatabaseName("ix_executor_executor_status_id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_executor_id");

                    b.ToTable("executor", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.ExecutorStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("code");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean")
                        .HasColumnName("is_actual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id")
                        .HasName("pk_executor_status");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_executor_status_id");

                    b.ToTable("executor_status", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("delivery_address");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("delivery_time");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<Guid?>("ExecutorId")
                        .HasColumnType("uuid")
                        .HasColumnName("executor_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("integer")
                        .HasColumnName("order_status_id");

                    b.Property<string>("ReceiptAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("receipt_address");

                    b.Property<DateTime>("ReceiptTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("receipt_time");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_order");

                    b.HasIndex("ExecutorId")
                        .HasDatabaseName("ix_order_executor_id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_order_id");

                    b.HasIndex("OrderStatusId")
                        .HasDatabaseName("ix_order_order_status_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_order_user_id");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.OrderHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<int>("OrderHistoryMethodId")
                        .HasColumnType("integer")
                        .HasColumnName("order_history_method_id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id")
                        .HasName("pk_order_history");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_order_history_id");

                    b.HasIndex("OrderHistoryMethodId")
                        .HasDatabaseName("ix_order_history_order_history_method_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_history_order_id");

                    b.ToTable("order_history", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.OrderHistoryMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("code");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean")
                        .HasColumnName("is_actual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id")
                        .HasName("pk_order_history_method");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_order_history_method_id");

                    b.ToTable("order_history_method", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("code");

                    b.Property<bool>("IsActual")
                        .HasColumnType("boolean")
                        .HasColumnName("is_actual");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id")
                        .HasName("pk_order_status");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_order_status_id");

                    b.ToTable("order_status", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasColumnName("ts")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id")
                        .HasName("pk_user");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ix_user_id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Cargo", b =>
                {
                    b.HasOne("ExpressDelivery.Domain.CargoType", "CargoType")
                        .WithMany()
                        .HasForeignKey("CargoTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_cargo_cargo_type_cargo_type_id");

                    b.HasOne("ExpressDelivery.Domain.Order", "Order")
                        .WithMany("Cargos")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_cargo_order_order_id");

                    b.Navigation("CargoType");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Executor", b =>
                {
                    b.HasOne("ExpressDelivery.Domain.ExecutorStatus", "ExecutorStatus")
                        .WithMany()
                        .HasForeignKey("ExecutorStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_executor_executor_status_executor_status_id");

                    b.Navigation("ExecutorStatus");
                });

            modelBuilder.Entity("ExpressDelivery.Domain.Order", b =>
                {
                    b.HasOne("ExpressDelivery.Domain.Executor", "Executor")
                        .WithMany("Orders")
                        .HasForeignKey("ExecutorId")
                        .HasConstraintName("fk_order_executor_executor_id");

                    b.HasOne("ExpressDelivery.Domain.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_order_status_order_status_id");

                    b.HasOne("ExpressDelivery.Domain.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_user_user_id");

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
                        .IsRequired()
                        .HasConstraintName("fk_order_history_order_history_method_order_history_method_id");

                    b.HasOne("ExpressDelivery.Domain.Order", "Order")
                        .WithMany("OrderHistories")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_history_order_order_id");

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
