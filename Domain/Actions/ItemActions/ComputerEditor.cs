using Domain.Interfaces.ItemInterface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions.ItemActions
{
    public class ComputerEditor : IComputerEditor
    {
        public ComputerModel CreateItem(ComputerModel item, List<ItemModel> items)
        {
            var computer = new ComputerModel
            {
                Name = item.Name,
                Price = item.Price,
                Rating = item.Rating,
                CPU = item.CPU,
                GPU = item.CPU,
                Producer = item.Producer
            };
            if (items.Any(i => i.Id == item.Id))
            {
                throw new ArgumentException("Item with the same Id already exists.");
            }
            items.Add(computer);
            return computer;
        }
    }
}
