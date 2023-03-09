using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ComputerModel> Computers { get; set;}
        public DbSet<TelephoneModel> Telephones { get; set; }
        public DbSet<BasketModel<ItemModel>> Baskets { get; set; }
        
    }
}
