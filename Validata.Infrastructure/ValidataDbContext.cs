using System;
using Microsoft.EntityFrameworkCore;
using Validata.Domain.Domain;

namespace Validata.Infrastructure
{
    public class ValidataDbContext : DbContext
    {
        public ValidataDbContext(DbContextOptions<ValidataDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }
    }
}
