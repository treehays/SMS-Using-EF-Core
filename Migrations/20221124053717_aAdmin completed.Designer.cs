// <auto-generated />

#nullable disable

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMS.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221124053717_aAdmin completed")]
    partial class aAdmincompleted
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Admin", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Pin")
                        .HasColumnType("longtext");

                    b.Property<string>("Post")
                        .HasColumnType("longtext");

                    b.HasKey("StaffId");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("Attendant", b =>
                {
                    b.Property<string>("StaffId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Pin")
                        .HasColumnType("longtext");

                    b.Property<string>("Post")
                        .HasColumnType("longtext");

                    b.HasKey("StaffId");

                    b.ToTable("attendants");
                });

            modelBuilder.Entity("Product", b =>
                {
                    b.Property<string>("BarCode")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.HasKey("BarCode");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Transaction", b =>
                {
                    b.Property<string>("ReceiptNo")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("BarCode")
                        .HasColumnType("longtext");

                    b.Property<decimal>("CashTender")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("ReceiptNo");

                    b.ToTable("transaction");
                });
#pragma warning restore 612, 618
        }
    }
}
