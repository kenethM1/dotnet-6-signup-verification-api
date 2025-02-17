﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220607032258_addPaymentCustomerTable")]
    partial class addPaymentCustomerTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BankAccount", b =>
                {
                    b.Property<int>("BankAccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountHolder")
                        .HasColumnType("longtext");

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AccountNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("AcountType")
                        .HasColumnType("longtext");

                    b.Property<string>("BankName")
                        .HasColumnType("longtext");

                    b.Property<string>("Currency")
                        .HasColumnType("longtext");

                    b.Property<int?>("SellerFormIdSellerForm")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("BankAccountId");

                    b.HasIndex("AccountId");

                    b.HasIndex("SellerFormIdSellerForm");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Cards", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("CVVHash")
                        .HasColumnType("longtext");

                    b.Property<string>("CardNetwork")
                        .HasColumnType("longtext");

                    b.Property<string>("CardNumberHash")
                        .HasColumnType("longtext");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("CardId");

                    b.HasIndex("AccountId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("CustomerPayment", b =>
                {
                    b.Property<int>("CustomerPaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Amount")
                        .HasColumnType("double");

                    b.Property<string>("CustomerId")
                        .HasColumnType("longtext");

                    b.Property<int?>("CustomerId1")
                        .HasColumnType("int");

                    b.Property<string>("PayGateTransactionId")
                        .HasColumnType("longtext");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("CustomerPaymentId");

                    b.HasIndex("CustomerId1");

                    b.HasIndex("SaleId")
                        .IsUnique();

                    b.ToTable("CustomerPayment");
                });

            modelBuilder.Entity("Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SaleDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("PaymentId");

                    b.HasIndex("SaleDetailId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BillingAddress")
                        .HasColumnType("longtext");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ShippingAddress")
                        .HasColumnType("longtext");

                    b.HasKey("SaleId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Sale");
                });

            modelBuilder.Entity("SaleDetail", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SaleId1")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.HasKey("SaleId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId1");

                    b.HasIndex("SellerId");

                    b.ToTable("SaleDetail");
                });

            modelBuilder.Entity("SellerForm", b =>
                {
                    b.Property<int>("IdSellerForm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AcceptAllTerms")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("AcceptDevolutionConditions")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("DNI")
                        .HasColumnType("longtext");

                    b.Property<string>("DNIImage_Back")
                        .HasColumnType("longtext");

                    b.Property<string>("DNIImage_Front")
                        .HasColumnType("longtext");

                    b.Property<int>("IdAccount")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<bool>("isApproved")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdSellerForm");

                    b.ToTable("SellerForm");
                });

            modelBuilder.Entity("Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Size");
                });

            modelBuilder.Entity("WebApi.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AcceptTerms")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("PasswordReset")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("longtext");

                    b.Property<string>("ResetToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("VerificationCode")
                        .HasColumnType("longtext");

                    b.Property<string>("VerificationToken")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Verified")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("WebApi.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("WebApi.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsSelled")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Stars")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("SizeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BankAccount", b =>
                {
                    b.HasOne("WebApi.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("SellerForm", "SellerForm")
                        .WithMany("BankAccount")
                        .HasForeignKey("SellerFormIdSellerForm");

                    b.Navigation("Account");

                    b.Navigation("SellerForm");
                });

            modelBuilder.Entity("Cards", b =>
                {
                    b.HasOne("WebApi.Entities.Account", "Account")
                        .WithMany("Cards")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CustomerPayment", b =>
                {
                    b.HasOne("WebApi.Entities.Account", "Customer")
                        .WithMany("CustomerPayment")
                        .HasForeignKey("CustomerId1");

                    b.HasOne("Sale", "Sale")
                        .WithOne("CustomerPayment")
                        .HasForeignKey("CustomerPayment", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Payment", b =>
                {
                    b.HasOne("SaleDetail", "Sale")
                        .WithMany()
                        .HasForeignKey("SaleDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Sale", b =>
                {
                    b.HasOne("WebApi.Entities.Account", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("SaleDetail", b =>
                {
                    b.HasOne("WebApi.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sale", null)
                        .WithMany("SaleDetails")
                        .HasForeignKey("SaleId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Entities.Account", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("WebApi.Entities.Account", b =>
                {
                    b.OwnsMany("WebApi.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<int>("AccountId")
                                .HasColumnType("int");

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("longtext");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("ReasonRevoked")
                                .HasColumnType("longtext");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("longtext");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("longtext");

                            b1.Property<string>("Token")
                                .HasColumnType("longtext");

                            b1.HasKey("Id");

                            b1.HasIndex("AccountId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner("Account")
                                .HasForeignKey("AccountId");

                            b1.Navigation("Account");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("WebApi.Entities.Image", b =>
                {
                    b.HasOne("WebApi.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApi.Entities.Product", b =>
                {
                    b.HasOne("WebApi.Entities.Account", "Account")
                        .WithMany("Products")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Currency");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Sale", b =>
                {
                    b.Navigation("CustomerPayment");

                    b.Navigation("SaleDetails");
                });

            modelBuilder.Entity("SellerForm", b =>
                {
                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("WebApi.Entities.Account", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("CustomerPayment");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebApi.Entities.Product", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
