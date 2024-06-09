﻿// <auto-generated />
using System;
using API.FurnitureStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.FurnitureStore.Data.Migrations
{
    [DbContext(typeof(APIFurnitureStoreContext))]
    [Migration("20240606064805_order details added")]
    partial class orderdetailsadded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("API.FurnitureStore.Shared.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("API.FurnitureStore.Shared.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("clientID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("deliveryDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("orderNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("API.FurnitureStore.Shared.OrderDetail", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("API.FurnitureStore.Shared.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("price")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("API.FurnitureStore.Shared.ProductCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("API.FurnitureStore.Shared.OrderDetail", b =>
                {
                    b.HasOne("API.FurnitureStore.Shared.Order", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.FurnitureStore.Shared.Product", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.FurnitureStore.Shared.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("API.FurnitureStore.Shared.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}