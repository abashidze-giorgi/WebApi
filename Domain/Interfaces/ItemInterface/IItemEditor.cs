using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ItemInterface
{
    public interface IItemEditor<T, T1> where T : ItemModel
    {
        public T CreateItem(T item, List<T1> items);
    }
}
