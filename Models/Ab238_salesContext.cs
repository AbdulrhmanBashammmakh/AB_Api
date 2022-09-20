using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AB_Api.Models
{
    public partial class Ab238_salesContext : DbContext
    {
       

        public Ab238_salesContext(DbContextOptions<Ab238_salesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CurrentProduct> CurrentProducts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Orderline> Orderlines { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<QtyNewAddition> QtyNewAdditions { get; set; } = null!;
        public virtual DbSet<ReturnSale> ReturnSales { get; set; } = null!;
        public virtual DbSet<Returnline> Returnlines { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_100_CI_AI");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cate");
            });

            modelBuilder.Entity<CurrentProduct>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("current_products");

                entity.Property(e => e.IdProduct)
                    .ValueGeneratedNever()
                    .HasColumnName("id_product");

                entity.Property(e => e.Detials)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("detials");

                entity.Property(e => e.PriceBuy)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price_buy");

                entity.Property(e => e.PriceSale)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price_sale");

                entity.Property(e => e.QtyAvaliabe).HasColumnName("qty_avaliabe");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasColumnName("upd_date");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NameCust)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_cust");

                entity.Property(e => e.PhoneCust)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone_cust");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.IdInvoice);

                entity.ToTable("invoice");

                entity.Property(e => e.IdInvoice).HasColumnName("id_invoice");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.IdCust).HasColumnName("id_cust");

                entity.Property(e => e.Net)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("net");

                entity.Property(e => e.Payment)
                    .HasMaxLength(10)
                    .HasColumnName("payment")
                    .IsFixedLength();

                entity.Property(e => e.Total)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total");

                entity.HasOne(d => d.IdCustNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.IdCust)
                    .HasConstraintName("FK_invoice_customer");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CrDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cr_date");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.HasOne(d => d.Cust)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustId)
                    .HasConstraintName("FK_order_customer");
            });

            modelBuilder.Entity<Orderline>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.ToTable("orderlines");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subtotal");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderlines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderlines_order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderlines)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_orderlines_products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CateId).HasColumnName("cate_id");

                entity.Property(e => e.Code)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CrDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cr_date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UnitId).HasColumnName("unit_id");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK_products_categories");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_products_units");
            });

            modelBuilder.Entity<QtyNewAddition>(entity =>
            {
                entity.ToTable("Qty_new_addition");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CrDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cr_date");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Note)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.QtyAdd).HasColumnName("qty_add");
            });

            modelBuilder.Entity<ReturnSale>(entity =>
            {
                entity.ToTable("return_sales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CrDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cr_date");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");
            });

            modelBuilder.Entity<Returnline>(entity =>
            {
                entity.HasKey(e => new { e.IdProduct, e.IdReturn });

                entity.ToTable("returnlines");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.IdReturn).HasColumnName("id_return");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.QtyReturn).HasColumnName("qty_return");

                entity.Property(e => e.SubtotalReturn)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("subtotal_return");

                entity.HasOne(d => d.IdReturnNavigation)
                    .WithMany(p => p.Returnlines)
                    .HasForeignKey(d => d.IdReturn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_returnlines_return_sales");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("units");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Unit1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unit");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsAdmin).HasColumnName("is_admin");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
