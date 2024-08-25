using Application.Interfaces;
using Domain.Attributes;
using Domain.Banners;
using Domain.Baskets;
using Domain.Catalog;
using Domain.Orders;
using Domain.Payment;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigs;
using Persistence.Seeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class DatabaseContext:DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Banner> Banners { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //reflection
            foreach (var EntityType in modelBuilder.Model.GetEntityTypes()) 
            { 
                if (EntityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    modelBuilder.Entity(EntityType.Name).Property<DateTime>("InsertTime").HasDefaultValue(DateTime.Now);
                    modelBuilder.Entity(EntityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(EntityType.Name).Property<DateTime?>("RemoveTime");
                    modelBuilder.Entity(EntityType.Name).Property<bool>("IsRemoved").HasDefaultValue(false) ;
                }
            }
            modelBuilder.Entity<CatalogType>()
               .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            modelBuilder.Entity<BasketItem>()
              .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);
            modelBuilder.Entity<Basket>()
                .HasQueryFilter(m => EF.Property<bool>(m, "IsRemoved") == false);


            modelBuilder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
            DatabaseContextSeed.CatalogSeed(modelBuilder);

            modelBuilder.Entity<Order>().OwnsOne(p => p.Address);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var modifiedEntities=ChangeTracker.Entries().Where(p=>
            p.State== EntityState.Modified||
            p.State== EntityState.Added||
            p.State== EntityState.Deleted);
           
            foreach (var entity in modifiedEntities) 
            {
                var EntityType = entity.Context.Model.FindEntityType(entity.Entity.GetType());

                var inserted = EntityType.FindProperty("InsertTime");
                var updated = EntityType.FindProperty("UpdateTime");
                var removed = EntityType.FindProperty("RemoveTime");
                var isRemoved = EntityType.FindProperty("IsRemoved");

                if (entity.State==EntityState.Added && inserted!=null)
                {
                    entity.Property( "InsertTime").CurrentValue=DateTime.Now;

                }
                if (entity.State == EntityState.Modified && updated != null)
                {
                    entity.Property("UpdateTime").CurrentValue = DateTime.Now;

                }
                if (entity.State == EntityState.Deleted && removed != null && isRemoved != null)
                {
                    entity.Property("RemoveTime").CurrentValue = DateTime.Now;
                    entity.Property("IsRemoved").CurrentValue = true;
                    entity.State = EntityState.Modified;

                }

            }

         
           


            return base.SaveChanges();
        }

    }
}
