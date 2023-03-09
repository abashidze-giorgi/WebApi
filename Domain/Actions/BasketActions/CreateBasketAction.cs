using Domain.Interfaces.BasketInterfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions.BasketActions
{
    public class CreateBasketAction : ICreateNewBasket
    {
        public BasketModel Create(UserModel user)
        {
            BasketModel basket = new BasketModel
            {
                UserId = user.Id
            };
            user.BasketId = basket.Id;
            return basket;
        }
    }
}
