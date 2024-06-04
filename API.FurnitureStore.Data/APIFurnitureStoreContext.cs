﻿using API.FurnitureStore.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace API.FurnitureStore.Data
{
    public class APIFurnitureStoreContext : DbContext
    {
        public APIFurnitureStoreContext(DbContextOptions options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductCategory> ProductCategories {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }
    }
}

