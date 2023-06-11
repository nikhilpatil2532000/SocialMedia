using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SocialMediaBrain.DatabaseFirstApproach;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Relationship> Relationships { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:SocialMediaBrainContext");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Relationship>(entity =>
        {
            entity.HasKey(e => e.RelationshipNo).HasName("PK__Relation__31FC6B813E9847FC");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FriendId).HasColumnName("FriendID");
            entity.Property(e => e.RelationIsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Friend).WithMany(p => p.RelationshipFriends)
                .HasForeignKey(d => d.FriendId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relations__Frien__2BFE89A6");

            entity.HasOne(d => d.User).WithMany(p => p.RelationshipUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Relations__UserI__2B0A656D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C4FA09FA0");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
