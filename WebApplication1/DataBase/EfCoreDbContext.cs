﻿using Delivery.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace Delivery.DataBase
{
    public class EfCoreDbContext : DbContext
    {
        private readonly string _connectionString =
        "Server=DESKTOP-F7HKUSS\\SQLEXPRESS;Database=DeliveryService;Trusted_Connection=True;TrustServerCertificate=True;";

        public DbSet<UserModel> Accounts { get; set; }
        public DbSet<PurchaseModel> Purchases { get; set; }
        public DbSet<ProductBasket> Basket { get; set; }
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_connectionString);
            base.OnConfiguring(builder);
        }
    }
}
