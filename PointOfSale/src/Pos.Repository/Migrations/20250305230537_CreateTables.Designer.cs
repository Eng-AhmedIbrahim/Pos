﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pos.Repository.Data;

#nullable disable

namespace Pos.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250305230537_CreateTables")]
    partial class CreateTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("POS.Core.Entities.Categorie.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<int>("BranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<bool>("Invisible")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("ItemsFont")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NormalizedEnglishName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("POS.Core.Entities.Company.Branch", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.Property<int>("LogoHeight")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(100);

                    b.Property<int>("LogoWidth")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(200);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Phone1")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Phone2")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar");

                    b.Property<bool>("Suspend")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("POS.Core.Entities.Company.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.Property<string>("NormalizedEnglishName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar");

                    b.Property<string>("Website")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("POS.Core.Entities.Customer.TakeawayCustomer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerPhone")
                        .IsUnique();

                    b.ToTable("TakeawayCustomers", (string)null);
                });

            modelBuilder.Entity("POS.Core.Entities.Item.AttributeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppearanceIndex")
                        .HasColumnType("int");

                    b.Property<int>("AttributeId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedMenuItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("RelatedMenuItemId");

                    b.ToTable("AttributeItems");
                });

            modelBuilder.Entity("POS.Core.Entities.Item.Attributes", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("POS.Core.Entities.Item.MenuSalesItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<int?>("AttributeId")
                        .HasColumnType("int");

                    b.Property<decimal?>("AttributePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BackColor")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<string>("Barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<decimal?>("FifthPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("FourthPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("HasAttribute")
                        .HasColumnType("bit");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("Invisible")
                        .HasColumnType("bit");

                    b.Property<string>("MainCategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEnglishName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SecondPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TextColor")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<int?>("TextSize")
                        .HasColumnType("int");

                    b.Property<decimal?>("ThirdPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId")
                        .IsUnique()
                        .HasFilter("[AttributeId] IS NOT NULL");

                    b.HasIndex("BranchId");

                    b.HasIndex("CategoryId");

                    b.ToTable("MenuSalesItems");
                });

            modelBuilder.Entity("POS.Core.Entities.Item.OrderItemAttributes", b =>
                {
                    b.Property<int>("OrderItemId")
                        .HasColumnType("int");

                    b.Property<int?>("AttributeItemId")
                        .HasColumnType("int");

                    b.Property<string>("AttributeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId", "AttributeItemId");

                    b.HasIndex("AttributeItemId");

                    b.ToTable("OrderItemAttributes");
                });

            modelBuilder.Entity("POS.Core.Entities.Kitchen.KitchenType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("KitchenName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("KitchenTypes", (string)null);
                });

            modelBuilder.Entity("POS.Core.Entities.Kitchen.OrderSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("AddServiceToItemPrice")
                        .HasColumnType("bit");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<int?>("ClosingReceiptCount")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerReceiptCount")
                        .HasColumnType("int");

                    b.Property<int?>("FullKitchenReceiptCount")
                        .HasColumnType("int");

                    b.Property<int?>("JobID")
                        .HasColumnType("int");

                    b.Property<string>("OrderStatment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SeparateReceiptCount")
                        .HasColumnType("int");

                    b.Property<decimal?>("Service")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Tips")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("OrderSettings");
                });

            modelBuilder.Entity("POS.Core.Entities.Kitchen.PrintingSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("ComputerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Copy1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Copy2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Copy3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Copy4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Copy5")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KitchenId")
                        .HasColumnType("int");

                    b.Property<string>("OrderType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("kitchenName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BranchID");

                    b.HasIndex("KitchenId");

                    b.ToTable("PrintingSettings", (string)null);
                });

            modelBuilder.Entity("POS.Core.Entities.OrderEntity.OrderItemsDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Discount")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsVoided")
                        .HasColumnType("bit");

                    b.Property<int?>("MenuSalesItemId")
                        .HasColumnType("int");

                    b.Property<int?>("MenuSalesItemsId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("OrderType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<decimal?>("TotalAfterDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalDiscountAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalDiscountPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalDiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VoidAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuSalesItemId");

                    b.HasIndex("MenuSalesItemsId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrdersDetails");
                });

            modelBuilder.Entity("POS.Core.Entities.OrderEntity.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressNotice")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ApartmentNum")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("AssignTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("BackTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("BranchID")
                        .HasColumnType("int");

                    b.Property<string>("BranchName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CashierID")
                        .HasColumnType("int");

                    b.Property<string>("CashierName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("ClosingTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerCount")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("DeliveryCompany")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("DeliveryFees")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("DiscountBy")
                        .HasColumnType("int");

                    b.Property<string>("DiscountByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiscountPercentage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DiscountReason")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime?>("DiscountTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiscountType")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("DiscountedItems")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DispatchID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DriverID")
                        .HasColumnType("int");

                    b.Property<string>("DriverName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FloorNum")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<decimal?>("FreeItems")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GrandTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HomeNum")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<DateTime?>("KitchenOutTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<string>("OrderNotice")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("OrderState")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("Pending");

                    b.Property<string>("OrderType")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("TakeAway");

                    b.Property<DateTime?>("PackingOutTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Paid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PaymentMethod")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("Cash");

                    b.Property<string>("Phone1")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Phone2")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("PrintCount")
                        .HasColumnType("int");

                    b.Property<decimal?>("Remain")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ReservationPaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ReservationRemain")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ScheduleDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("Service")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ShiftID")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TableID")
                        .HasColumnType("int");

                    b.Property<string>("TableName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TableState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TakeawayCustomerId")
                        .HasColumnType("int");

                    b.Property<string>("TakeawayCustomerName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TakeawayCustomerPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("TakerID")
                        .HasColumnType("int");

                    b.Property<string>("TakerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TitleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TotalDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalVoid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("VoidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("VoidBy")
                        .HasColumnType("int");

                    b.Property<string>("VoidByName")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int?>("VoidCount")
                        .HasColumnType("int");

                    b.Property<string>("VoidReason")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("VoidTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WaiterID")
                        .HasColumnType("int");

                    b.Property<string>("WaiterName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("WithoutDeliveryFees")
                        .HasColumnType("bit");

                    b.Property<bool?>("WithoutService")
                        .HasColumnType("bit");

                    b.Property<bool?>("WithoutTax")
                        .HasColumnType("bit");

                    b.Property<decimal?>("ZoneBonus")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ZoneID")
                        .HasColumnType("int");

                    b.Property<string>("ZoneName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("TakeawayCustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("POS.Core.Entities.Categorie.Category", b =>
                {
                    b.HasOne("POS.Core.Entities.Company.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("POS.Core.Entities.Company.Branch", b =>
                {
                    b.HasOne("POS.Core.Entities.Company.Company", "Company")
                        .WithMany("Branches")
                        .HasForeignKey("CompanyId");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("POS.Core.Entities.Item.AttributeItem", b =>
                {
                    b.HasOne("POS.Core.Entities.Item.Attributes", "Attribute")
                        .WithMany("AttributeItems")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Core.Entities.Item.MenuSalesItems", "RelatedMenuItem")
                        .WithMany()
                        .HasForeignKey("RelatedMenuItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Attribute");

                    b.Navigation("RelatedMenuItem");
                });

            modelBuilder.Entity("POS.Core.Entities.Item.MenuSalesItems", b =>
                {
                    b.HasOne("POS.Core.Entities.Item.Attributes", "Attribute")
                        .WithOne()
                        .HasForeignKey("POS.Core.Entities.Item.MenuSalesItems", "AttributeId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("POS.Core.Entities.Company.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("POS.Core.Entities.Categorie.Category", "Category")
                        .WithMany("MenuSalesItems")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Attribute");

                    b.Navigation("Branch");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("POS.Core.Entities.Item.OrderItemAttributes", b =>
                {
                    b.HasOne("POS.Core.Entities.Item.AttributeItem", "AttributeItem")
                        .WithMany()
                        .HasForeignKey("AttributeItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("POS.Core.Entities.OrderEntity.OrderItemsDetails", "OrderItem")
                        .WithMany("OrderItemAttributes")
                        .HasForeignKey("OrderItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttributeItem");

                    b.Navigation("OrderItem");
                });

            modelBuilder.Entity("POS.Core.Entities.Kitchen.PrintingSettings", b =>
                {
                    b.HasOne("POS.Core.Entities.Kitchen.KitchenType", "Kitchen")
                        .WithMany()
                        .HasForeignKey("KitchenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Kitchen");
                });

            modelBuilder.Entity("POS.Core.Entities.OrderEntity.OrderItemsDetails", b =>
                {
                    b.HasOne("POS.Core.Entities.Item.MenuSalesItems", "MenuSalesItem")
                        .WithMany()
                        .HasForeignKey("MenuSalesItemId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("POS.Core.Entities.Item.MenuSalesItems", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("MenuSalesItemsId");

                    b.HasOne("POS.Core.Entities.OrderEntity.Orders", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuSalesItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("POS.Core.Entities.OrderEntity.Orders", b =>
                {
                    b.HasOne("POS.Core.Entities.Customer.TakeawayCustomer", "TakeawayCustomer")
                        .WithMany("Orders")
                        .HasForeignKey("TakeawayCustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("TakeawayCustomer");
                });

            modelBuilder.Entity("POS.Core.Entities.Categorie.Category", b =>
                {
                    b.Navigation("MenuSalesItems");
                });

            modelBuilder.Entity("POS.Core.Entities.Company.Company", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("POS.Core.Entities.Customer.TakeawayCustomer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("POS.Core.Entities.Item.Attributes", b =>
                {
                    b.Navigation("AttributeItems");
                });

            modelBuilder.Entity("POS.Core.Entities.Item.MenuSalesItems", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("POS.Core.Entities.OrderEntity.OrderItemsDetails", b =>
                {
                    b.Navigation("OrderItemAttributes");
                });

            modelBuilder.Entity("POS.Core.Entities.OrderEntity.Orders", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
