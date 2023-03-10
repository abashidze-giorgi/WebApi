using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BasketModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // свойство для связи с пользователем
        public int ItemId { get; set; }
        public List<ItemModel> Items { get; set; } = new List<ItemModel>();  // список товаров в корзине
    }
}
