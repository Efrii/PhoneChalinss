﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneChalin.Context;

namespace PhoneChalin.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220704154931_addOne")]
    partial class addOne
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneChalin.Models.Buyer", b =>
                {
                    b.Property<int>("IdBuyer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(1)")
                        .HasMaxLength(1);

                    b.Property<string>("NameBuyer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.HasKey("IdBuyer");

                    b.ToTable("Buyers");
                });

            modelBuilder.Entity("PhoneChalin.Models.Smartphone", b =>
                {
                    b.Property<int>("IdSmartphone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdSupplier")
                        .HasColumnType("int");

                    b.Property<string>("NameSmartphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceSmartphone")
                        .HasColumnType("int");

                    b.Property<int>("StockSmartphoen")
                        .HasColumnType("int");

                    b.HasKey("IdSmartphone");

                    b.HasIndex("IdSupplier");

                    b.ToTable("Smartphones");
                });

            modelBuilder.Entity("PhoneChalin.Models.Supplier", b =>
                {
                    b.Property<int>("IdSupplier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandSupplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSupplier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.HasKey("IdSupplier");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("PhoneChalin.Models.Smartphone", b =>
                {
                    b.HasOne("PhoneChalin.Models.Supplier", "supplierModel")
                        .WithMany()
                        .HasForeignKey("IdSupplier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}