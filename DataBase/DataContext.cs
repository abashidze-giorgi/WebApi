using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BasketModel> Baskets { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ComputerModel> Computers { get; set; }
        public DbSet<TelephoneModel> Telephones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<UserModel>()
                    .HasOne(u => u.Basket)  // один пользователь имеет одну корзину
                    .WithOne()   // одна корзина принадлежит одному пользователю
                    .HasForeignKey<BasketModel>(b => b.UserId); // связываем корзину с пользователем через поле UserId
        }
    }
}
