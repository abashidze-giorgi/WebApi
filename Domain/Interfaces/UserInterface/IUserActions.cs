using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UserInterface
{
    public interface IUserActions
    {
        public UserModel Create(List<UserModel> userList, UserModel request, out string result);
        public UserModel Update(List<UserModel> userList, UserModel user, out string result);
    }
}
