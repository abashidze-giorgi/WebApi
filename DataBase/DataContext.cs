using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //modelBuilder.Entity<BasketModel>()
            //.HasMany(b => b.Items)  // одна корзина может содержать множество товаров
            //.WithOne() // множество товаров относятся к одной корзине
            //.HasForeignKey(i => i.BasketId); // связываем товары с корзиной через поле BasketId

        }
    }
}
