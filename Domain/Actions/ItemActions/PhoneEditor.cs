using Domain.Interfaces.ItemInterface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions.ItemActions
{
    public class PhoneEditor : IPhoneEditor
    {
        public TelephoneModel CreateItem(TelephoneModel item, List<ItemModel> items)
        {
            var phone = new TelephoneModel
            {
                Name = item.Name,
                Price = item.Price,
                Rating = item.Rating,
                Battery = item.Battery,
                Display = item.Display,
                Model = item.Model,
            };
            if (items.Any(i => i.Id == item.Id))
            {
                throw new ArgumentException("Item with the same Id already exists.");
            }
            items.Add(phone);
            return phone;
        }
    }
}
