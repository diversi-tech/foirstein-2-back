using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dal.Modles;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<ApprovalRequest> ApprovalRequests { get; set; }

    public virtual DbSet<BorrowRequest> BorrowRequests { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<RatingNote> RatingNotes { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<SearchLog> SearchLogs { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=LIBRARY; Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Activity__7839F64DB11CC6A9");

            entity.ToTable("Activity_Logs");

            entity.Property(e => e.LogId).HasColumnName("logId");
            entity.Property(e => e.Activity)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("activity");
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("timestamp");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.ActivityLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Activity___userI__403A8C7D");
        });

        modelBuilder.Entity<ApprovalRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Approval__E3C5DE31C31E01AD");

            entity.ToTable("Approval_Requests");

            entity.Property(e => e.RequestId).HasColumnName("requestId");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("datetime")
                .HasColumnName("approvalDate");
            entity.Property(e => e.FromDate).HasColumnName("fromDate");
            entity.Property(e => e.ItemId).HasColumnName("itemId");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("requestDate");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending")
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("totalPrice");
            entity.Property(e => e.UntilDate).HasColumnName("untilDate");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");

            entity.HasOne(d => d.Item).WithMany(p => p.ApprovalRequests)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Approval___itemI__619B8048");

            entity.HasOne(d => d.User).WithMany(p => p.ApprovalRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Approval___userI__628FA481");
        });

        modelBuilder.Entity<BorrowRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Borrow_R__E3C5DE316A7BFA38");

            entity.ToTable("Borrow_Requests");

            entity.Property(e => e.RequestId).HasColumnName("requestId");
            entity.Property(e => e.ApprovalDate)
                .HasColumnType("datetime")
                .HasColumnName("approvalDate");
            entity.Property(e => e.FromDate).HasColumnName("fromDate");
            entity.Property(e => e.ItemId).HasColumnName("itemId");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("requestDate");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending")
                .HasColumnName("status");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("totalPrice");
            entity.Property(e => e.UntilDate).HasColumnName("untilDate");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");

            entity.HasOne(d => d.Item).WithMany(p => p.BorrowRequests)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Borrow_Re__itemI__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.BorrowRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Borrow_Re__userI__4F7CD00D");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Items__56A128AAA6E56D86");

            entity.Property(e => e.ItemId).HasColumnName("itemId");
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .HasColumnName("author");
            entity.Property(e => e.Category)
                .HasMaxLength(255)
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .HasColumnName("filePath");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");

            entity.HasMany(d => d.Tags).WithMany(p => p.Items)
                .UsingEntity<Dictionary<string, object>>(
                    "ItemsTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Items_Tag__tagId__5BE2A6F2"),
                    l => l.HasOne<Item>().WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Items_Tag__itemI__5AEE82B9"),
                    j =>
                    {
                        j.HasKey("ItemId", "TagId").HasName("PK__Items_Ta__33AEE8BFB9077F03");
                        j.ToTable("Items_Tags");
                        j.IndexerProperty<int>("ItemId").HasColumnName("itemId");
                        j.IndexerProperty<int>("TagId").HasColumnName("tagId");
                    });
        });

        modelBuilder.Entity<RatingNote>(entity =>
        {
            entity.HasKey(e => e.RatingNoteId).HasName("PK__Rating_N__4B36B4BE9F2800C8");

            entity.ToTable("Rating_Note");

            entity.Property(e => e.RatingNoteId).HasColumnName("ratingNoteId");
            entity.Property(e => e.ItemId).HasColumnName("itemId");
            entity.Property(e => e.Note)
                .HasMaxLength(255)
                .HasColumnName("note");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");

            entity.HasOne(d => d.Item).WithMany(p => p.RatingNotes)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Rating_No__itemI__5629CD9C");

            entity.HasOne(d => d.User).WithMany(p => p.RatingNotes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Rating_No__userI__571DF1D5");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__Reports__1C9B4E2DB70235FA");

            entity.Property(e => e.ReportId).HasColumnName("reportId");
            entity.Property(e => e.GeneratedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("generatedAt");
            entity.Property(e => e.GeneratedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("generatedBy");
            entity.Property(e => e.ReportData)
                .HasColumnType("text")
                .HasColumnName("reportData");
            entity.Property(e => e.ReportName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("reportName");

            entity.HasOne(d => d.GeneratedByNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.GeneratedBy)
                .HasConstraintName("FK__Reports__generat__440B1D61");
        });

        modelBuilder.Entity<SearchLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Search_L__7839F64DCB48EE1D");

            entity.ToTable("Search_Logs");

            entity.Property(e => e.LogId).HasColumnName("logId");
            entity.Property(e => e.SearchDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("searchDate");
            entity.Property(e => e.SearchQuery)
                .HasMaxLength(255)
                .HasColumnName("searchQuery");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.SearchLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Search_Lo__userI__534D60F1");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tags__50FC015700ADD26E");

            entity.HasIndex(e => e.TagName, "UQ__Tags__288C385117B1422B").IsUnique();

            entity.Property(e => e.TagId).HasColumnName("tagId");
            entity.Property(e => e.TagName)
                .HasMaxLength(255)
                .HasColumnName("tagName");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__CB9A1CFF8DDF7FA4");

            entity.HasIndex(e => e.Email, "UQ__Users__AB6E6164C826B575").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__Users__F3DBC5727FEB2F2D").IsUnique();

            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwordHash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.ProfilePicture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("profilePicture");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UserDob).HasColumnName("userDOB");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
