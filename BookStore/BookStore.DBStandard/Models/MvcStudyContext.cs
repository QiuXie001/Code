using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DBStandard.Models;

public partial class MvcStudyContext : DbContext
{
    public MvcStudyContext()
    {
    }

    public MvcStudyContext(DbContextOptions<MvcStudyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookType> BookTypes { get; set; }

    public virtual DbSet<Custom> Customs { get; set; }

    public virtual DbSet<Detail> Details { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=QIU;Database=mvcStudy;Trusted_Connection=True;Encrypt=False;User ID=sa;Password=123qwe");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
            entity.Property(e => e.AdminAge)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Admin_Age");
            entity.Property(e => e.AdminIdentityId)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Admin_IdentityID");
            entity.Property(e => e.AdminName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Admin_Name");
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Admin_Password");
            entity.Property(e => e.AdminTelephone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Admin_Telephone");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.BookId).HasColumnName("Book_ID");
            entity.Property(e => e.AuthorName).HasMaxLength(50);
            entity.Property(e => e.BookCoverUrl).HasMaxLength(1024);
            entity.Property(e => e.BookTag).HasMaxLength(50);
            entity.Property(e => e.BookTypeId).HasColumnName("BookTypeID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(160);

            entity.HasOne(d => d.BookType).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_BookTypes");
        });

        modelBuilder.Entity<BookType>(entity =>
        {
            entity.Property(e => e.BookTypeId)
                .ValueGeneratedNever()
                .HasColumnName("BookTypeID");
            entity.Property(e => e.BookType1)
                .HasMaxLength(50)
                .HasColumnName("BookType");
        });

        modelBuilder.Entity<Custom>(entity =>
        {
            entity.ToTable("Custom");

            entity.Property(e => e.CustomId).HasColumnName("Custom_ID");
            entity.Property(e => e.AdminIdentityId)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Admin_IdentityID");
            entity.Property(e => e.CustomAge)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Custom_Age");
            entity.Property(e => e.CustomName)
                .HasMaxLength(50)
                .HasColumnName("Custom_Name");
            entity.Property(e => e.CustomPassword)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Custom_Password");
            entity.Property(e => e.CustomTelephone)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Custom_Telephone");
        });

        modelBuilder.Entity<Detail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Detail");

            entity.Property(e => e.Address).HasMaxLength(1024);
            entity.Property(e => e.AuthorName).HasMaxLength(50);
            entity.Property(e => e.BookCoverUrl).HasMaxLength(1024);
            entity.Property(e => e.BookTag).HasMaxLength(50);
            entity.Property(e => e.BookType).HasMaxLength(50);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(160);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.Address).HasMaxLength(1024);
            entity.Property(e => e.BookId)
                .HasMaxLength(1024)
                .HasColumnName("Book_ID");
            entity.Property(e => e.CustomId).HasColumnName("Custom_ID");
            entity.Property(e => e.OrderTime)
                .HasColumnType("datetime")
                .HasColumnName("Order_Time");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.Property(e => e.PurchaseId)
                .ValueGeneratedNever()
                .HasColumnName("Purchase_ID");
            entity.Property(e => e.AdminId).HasColumnName("Admin_ID");
            entity.Property(e => e.BookId)
                .HasMaxLength(1024)
                .HasColumnName("Book_ID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PurchaseTime)
                .HasColumnType("datetime")
                .HasColumnName("Purchase_Time");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
