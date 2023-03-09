using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ItemInterface
{
    public interface IItemActions<L, I, R> where I : ItemModel where R : ItemModel
    {
        public R Create(L itemList, I item, out string result);
        public R Update(L itemList, I item, out string result);

        public bool CheckItemExist(L itemList, I item, out string result);
        public bool CheckItemWhenEdit(L itemList, I item, out string result);
    }
}
   