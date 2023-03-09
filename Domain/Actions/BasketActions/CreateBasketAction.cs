using Domain.Interfaces.BasketInterfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions.BasketActions
{
    public class CreateBasketAction : ICreateNewBasket<ItemModel>
    {
        //public BasketModel Create(UserModel user)
        //{
        //    BasketModel basket = new BasketModel
        //    {
        //        UserId = user.Id
        //    };
        //    user.BasketId = basket.Id;
        //    return basket;
        //}
        public BasketModel<ItemModel> Create(UserModel user)
        {
            var computers = new List<ComputerModel> { /* ... */ };
            var phones = new List<TelephoneModel> { /* ... */ };

            var items = new List<ItemModel>();
            items.AddRange(computers);
            items.AddRange(phones);
            var basket = new BasketModel<ItemModel>
            {
                UserId = user.Id
            };
            user.BasketId = basket.Id;
            return basket;
        }
    }
}
