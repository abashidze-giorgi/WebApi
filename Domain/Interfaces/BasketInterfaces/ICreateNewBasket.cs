using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.BasketInterfaces
{
    public interface ICreateNewBasket
    {
        public BasketModel Create(UserModel user);
    }
}
