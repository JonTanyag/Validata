using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        //public virtual DbSet<Item> Items { get; set; }
        //public virtual DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("Server=localhost,1433\\Catalog=Validata;Database=Validata;User=sa;Password=m$sQlServ3rh4ck");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //var settings = Configuration.GetSection("ConnectionStrings:DefaultConnection");
            base.OnModelCreating(builder);
        }

        
    }
}
