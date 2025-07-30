using System;
using Microsoft.EntityFrameworkCore;

namespace APi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Models.User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Models.User>().ToTable("Users");
        modelBuilder.Entity<Models.User>().HasData(
            new Models.User { Id = "bob-bo", Name = "testuser1" },
            new Models.User { Id = "alice-smith", Name = "testuser2" }
        );
    }
}
