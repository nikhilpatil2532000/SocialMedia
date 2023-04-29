using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SocialMediaBrain.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
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
            entity.HasKey(e => e.RelationshipNo).HasName("PK__Relation__31FC6B811E7FE644");

            entity.Property(e => e.FriendId).HasColumnName("FriendID");
            entity.Property(e => e.RelationIsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Friend).WithMany(p => p.RelationshipFriends)
                .HasForeignKey(d => d.FriendId)
                .HasConstraintName("FK__Relations__Frien__5DCAEF64");

            entity.HasOne(d => d.User).WithMany(p => p.RelationshipUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Relations__UserI__5CD6CB2B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasDefaultValueSql("(N'')");
            entity.Property(e => e.Password).HasDefaultValueSql("(N'')");
            entity.Property(e => e.PhoneNumber).HasDefaultValueSql("(N'')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
