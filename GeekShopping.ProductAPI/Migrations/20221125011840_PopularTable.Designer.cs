﻿// <auto-generated />
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20221125011840_PopularTable")]
    partial class PopularTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GeekShopping.ProductAPI.Model.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("product");

                    b.HasData(
                        new
                        {
                            Id = 4L,
                            CategoryName = "Teste",
                            Description = "Alguma descrição",
                            ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/1_super_mario.jpg?raw=true",
                            Name = "Name",
                            Price = 69.9m
                        },
                        new
                        {
                            Id = 10L,
                            CategoryName = "Teste",
                            Description = "Nova descrição",
                            ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/1_super_mario.jpg?raw=true",
                            Name = "Marina",
                            Price = 1599.99m
                        },
                        new
                        {
                            Id = 11L,
                            CategoryName = "Teste",
                            Description = "Nova descrição",
                            ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/1_super_mario.jpg?raw=true",
                            Name = "Marina",
                            Price = 1599.99m
                        },
                        new
                        {
                            Id = 12L,
                            CategoryName = "Teste",
                            Description = "Nova descrição",
                            ImageUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/1_super_mario.jpg?raw=true",
                            Name = "Marina",
                            Price = 1599.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}