using Domain.Interfaces.ItemInterface;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions.ItemActions
{
    public class ComputerCreate : IItemActions<List<ComputerModel>, ComputerModel, ComputerModel>
    {

        public ComputerModel Create(List<ComputerModel> itemList, ComputerModel item, out string result)
        {
            try
            {
                var createdItem = new ComputerModel
                {
                    Name = item.Name,
                    CPU = item.CPU,
                    GPU = item.GPU,
                    Price = item.Price,
                    Producer = item.Producer,
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

        public ComputerModel Update(List<ComputerModel> itemList, ComputerModel item, out string result)
        {
            try
            {
                var newItem = new ComputerModel
                {
                    CPU = item.CPU,
                    GPU = item.CPU,
                    Price = item.Price,
                    Producer = item.Producer,
                    Rating = item.Rating,
                    Name = item.Name,
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
        public bool CheckItemExist(List<ComputerModel> itemList, ComputerModel item, out string result)
        {
            foreach (var u in itemList)
            {
                if (u.Name == item.Name && u.Producer == item.Producer)
                {
                    result = "Ok";
                    return true;
                }
            }
            result = "Can't find product";
            return false;
        }

        public bool CheckItemWhenEdit(List<ComputerModel> itemList, ComputerModel item, out string result)
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
    }
}
