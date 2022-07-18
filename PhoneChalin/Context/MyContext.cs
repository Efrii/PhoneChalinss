using System;
using Microsoft.EntityFrameworkCore;
using PhoneChalin.Models;

namespace PhoneChalin.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.IdUser);

            modelBuilder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.IdRole);
        }

        // dbset to model and database name for migration in database
        public DbSet<Smartphone> Smartphones { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
