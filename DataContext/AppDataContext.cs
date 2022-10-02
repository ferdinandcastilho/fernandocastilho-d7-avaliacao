using LoginScreenApp.DataContext.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LoginScreenApp.DataContext;

public sealed class AppDataContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data source = LoginApp.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(CreateDefaultUser());
        base.OnModelCreating(modelBuilder);
    }

    private static User CreateDefaultUser()
    {
        return new User(id: Guid.NewGuid(), userName: "admin", password: "123");
    }
}

