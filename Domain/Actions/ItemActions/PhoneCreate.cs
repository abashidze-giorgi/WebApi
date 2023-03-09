using Domain.Interfaces.ItemInterface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions.ItemActions
{
    public class PhoneCreate : IItemActions<List<TelephoneModel>, TelephoneModel, TelephoneModel>
    {

        public TelephoneModel Create(List<TelephoneModel> itemList, TelephoneModel item, out string result)
        {
            try
            {
                var createdItem = new TelephoneModel
                {
                    Name = item.Name,
                    Battery = item.Battery,
                    Display = item.Display,
                    Model = item.Model,
                    Price = item.Price,
                    Rating = item.Rating,
                };
                if (!CheckItemExist(itemList, createdItem, out result))
                {
                    result = "Ok";
                    return createdItem;
                }
                result = "Product exist";
                return item;
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return item;
            }
        }

        public TelephoneModel Update(List<TelephoneModel> itemList, TelephoneModel item, out string result)
        {
            try
            {
                var newItem = new TelephoneModel
                {
                    Name = item.Name,
                    Battery = item.Battery,
                    Display = item.Display,
                    Model = item.Model,
                    Price = item.Price,
                    Rating = item.Rating,
                };
                if (CheckItemWhenEdit(itemList, item, out result))
                {
                    newItem.Id = item.Id;
                    return newItem;
                }
                else
                {
                    return item;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return item;
            }
        }

        #region Private Methods

        public bool CheckItemExist(List<TelephoneModel> itemList, TelephoneModel item, out string result)
        {
            foreach (var u in itemList)
            {
                if (u.Name == item.Name && u.Model == item.Model)
                {
                    result = "Ok";
                    return true;
                }
            }
            result = "Can't find product";
            return false;
        }

        public bool CheckItemWhenEdit(List<TelephoneModel> itemList, TelephoneModel item, out string result)
        {
            foreach (var it in itemList)
            {
                if (it.Id == item.Id)
                {
                    result = "Ok";
                    return true;
                }
            }
            result = "Can't find user";
            return false;
        }
        #endregion
    }
}
