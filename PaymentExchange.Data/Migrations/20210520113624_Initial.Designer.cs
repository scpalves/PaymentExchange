﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PaymentExchange.Data.Context;

namespace PaymentExchange.Data.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20210520113624_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PaymentExchange.Business.Models.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientName")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("ClientPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("InvoiceTotalEarnings")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalMoneyDeduction")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TotalQuantityDeduction")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("PaymentExchange.Business.Models.InvoiceLine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ClientDeduction")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("InvoiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvoiceLineId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantityDeduction")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceLines");
                });

            modelBuilder.Entity("PaymentExchange.Business.Models.InvoiceLine", b =>
                {
                    b.HasOne("PaymentExchange.Business.Models.Invoice", "Invoice")
                        .WithMany("InvoiceLines")
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("PaymentExchange.Business.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceLines");
                });
#pragma warning restore 612, 618
        }
    }
}
