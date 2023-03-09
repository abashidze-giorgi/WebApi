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
        public bool CheckItemExist(List<TelephoneModel> itemList, TelephoneModel item, out string result)
        {
            throw new NotImplementedException();
        }

        public bool CheckItemWhenEdit(List<TelephoneModel> itemList, TelephoneModel item, out string result)
        {
            throw new NotImplementedException();
        }

        public TelephoneModel Create(List<TelephoneModel> itemList, TelephoneModel item, out string result)
        {
            throw new NotImplementedException();
        }

        public TelephoneModel Update(List<TelephoneModel> itemList, TelephoneModel item, out string result)
        {
            throw new NotImplementedException();
        }
    }
}
