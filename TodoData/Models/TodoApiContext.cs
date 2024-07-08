using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TodoData.Models;

public partial class TodoApiContext : DbContext
{
    public TodoApiContext()
    {
    }

    public TodoApiContext(DbContextOptions<TodoApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoList> TodoLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TodoAPI;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;");



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TodoList__3214EC077E93D3D6");

            entity.ToTable("TodoList");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.Title).HasMaxLength(128);
            entity.Property(e => e.IsCompleted);


        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
