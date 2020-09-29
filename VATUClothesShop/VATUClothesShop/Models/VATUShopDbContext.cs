using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VATUClothesShop.Models
{
    public class VATUShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public VATUShopDbContext(DbContextOptions<VATUShopDbContext> options) : base(options)
        {
             
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartDetail> ShoppingCartDetails { get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<Order>();
            //modelBuilder.Ignore<OrderDetail>();
            //modelBuilder.Ignore<Brand>();
            //modelBuilder.Ignore<Category>();
            //modelBuilder.Ignore<Product>();
            //modelBuilder.Ignore<ShoppingCart>();
            //modelBuilder.Ignore<ShoppingCartDetail>();

            modelBuilder.Entity<Order>()
            .HasOne<ApplicationUser>(o => o.AccountCustomer)
            .WithMany(a => a.Orders)
            .HasForeignKey(o => o.AccountCustomerId);

            modelBuilder.Entity<ShoppingCart>()
            .HasOne<ApplicationUser>(sh => sh.AccountCustomer)
            .WithMany(a => a.ShoppingCarts)
            .HasForeignKey(sh => sh.AccountCustomerId);
        }
    }
}
