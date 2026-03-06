using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TaskAPI.Models;

public partial class TaskMContext : DbContext
{
    public TaskMContext()
    {
    }

    public TaskMContext(DbContextOptions<TaskMContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskItem> TaskItem { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity
                .HasKey(t => t.Tid).HasName("PK_TaskItem");
           entity.ToTable("TaskItem");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity
                .HasKey( e=> e.Id).HasName("PK_User"); ;
            entity.ToTable("User");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.PasswordHash).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
