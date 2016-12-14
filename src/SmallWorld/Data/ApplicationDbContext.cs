using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmallWorld.Models;

namespace SmallWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<EmployeeItem> EmployeeItems { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EmployeeItem>().HasKey(x => new { x.ItemId, x.EmployeeId });
            builder.Entity<WarehouseItem>().HasKey(x => new { x.WarehouseId, x.ItemId });

            builder.Entity<Employee>()
                .HasMany(e => e.EmployeeItems)
                .WithOne(i => i.Employee)
                .IsRequired();

            builder.Entity<Warehouse>()
                .HasMany(w => w.WarehouseItems)
                .WithOne(i => i.Warehouse)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .HasMany(w => w.Warehouses)
                .WithOne(a => a.Admin)
                .IsRequired();
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
