using Domain.Interfaces.ItemInterface;
using Domain.Models;
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
        public ComputerModel Create<V>(List<ComputerModel> itemList, ComputerModel item)
        {
            // Implementation for creating a computer item
            ComputerModel createdItem = new ComputerModel();
            // set properties of createdItem
            return createdItem;
        }

        public ComputerModel Update<V>(List<ComputerModel> itemList, ComputerModel item)
        {
            // Implementation for updating a computer item
            ComputerModel updatedItem = new ComputerModel();
            // set properties of updatedItem
            return updatedItem;
        }
    }
}
