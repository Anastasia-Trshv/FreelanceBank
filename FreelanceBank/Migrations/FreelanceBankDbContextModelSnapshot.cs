﻿// <auto-generated />
using FreelanceBank.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FreelanceBank.Migrations
{
    [DbContext(typeof(FreelanceBankDbContext))]
    partial class FreelanceBankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FreelanceBank.Database.Entities.FreelanceWallet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("FreelanceWallets");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Balance = 100m
                        });
                });

            modelBuilder.Entity("FreelanceBank.Database.Entities.UserWallet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("money");

                    b.Property<decimal>("FreezeBalance")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("UserWallets");
                });
#pragma warning restore 612, 618
        }
    }
}
