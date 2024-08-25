using Domain.Banners;
using Domain.Baskets;
using Domain.Catalog;
using Domain.Orders;
using Domain.Payment;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDatabaseContext
    {

        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; } 
        public DbSet<CatalogItem> CatalogItems{ get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Banner> Banners { get; set; }

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry Entry([NotNullAttribute] object entity);
    }
}
