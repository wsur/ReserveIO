﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReserveIO.Models;

#nullable disable

namespace ReserveIO.Migrations
{
    [DbContext(typeof(UsersContext))]
    [Migration("20240506113750_AddUserRolesDB")]
    partial class AddUserRolesDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ReserveIO.Models.Role", b =>
                {
                    b.Property<int>("Role_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Role_ID"));

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Role_ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Role_ID = 1,
                            Role_Name = "Lessee"
                        },
                        new
                        {
                            Role_ID = 2,
                            Role_Name = "Lessor"
                        },
                        new
                        {
                            Role_ID = 3,
                            Role_Name = "App_Owner"
                        });
                });

            modelBuilder.Entity("ReserveIO.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 23,
                            Name = "Tom"
                        },
                        new
                        {
                            Id = 2,
                            Age = 26,
                            Name = "Alice"
                        },
                        new
                        {
                            Id = 3,
                            Age = 28,
                            Name = "Sam"
                        },
                        new
                        {
                            Id = 4,
                            Age = 24,
                            Name = "Eugene"
                        });
                });

            modelBuilder.Entity("ReserveIO.Models.UserRole", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"));

                    b.Property<int>("Role_ID")
                        .HasColumnType("int");

                    b.HasKey("User_ID");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            User_ID = 1,
                            Role_ID = 1
                        },
                        new
                        {
                            User_ID = 2,
                            Role_ID = 1
                        },
                        new
                        {
                            User_ID = 3,
                            Role_ID = 2
                        },
                        new
                        {
                            User_ID = 4,
                            Role_ID = 3
                        });
                });
#pragma warning restore 612, 618
        }
    }
}