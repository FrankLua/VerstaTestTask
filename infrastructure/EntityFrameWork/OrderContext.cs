using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EntityFrameWork
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options) 
        { 
        
        
        }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                Data = DateTime.Now,
                RecipientCityId = 1,
                AddressRecipient = "Ул Братьев Сизых 11",
                SenderCityId = 2,
                Weight = 24.6,
                AddressSender = "Ул Калашникова д3"
            });
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 1,
                DistrictId = 1,
                Name = "Москва",
                Prefix = "Moskva",
                TimeZone = "+4:00",
                TimeZone2 = "+5:00",
                RegionId = 2,
                Tz = "Europe/Moscow",


            });
        }
    }
}
