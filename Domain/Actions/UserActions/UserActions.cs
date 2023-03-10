using Domain.Interfaces;
using Domain.Interfaces.UserInterface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Actions.UserActions
{
    public class UserActions : IUserActions
    {
        public UserModel Create(List<UserModel> userList, UserModel request, out string result)
        {
            try
            {
                var user = new UserModel
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    UserName = request.UserName,
                    Password = request.Password,
                    Basket = new BasketModel()
                };
                if(!CheckUserExistWhenCreateNewUser(userList, user))
                {
                    result = "Ok";
                    return user;
                }
                else
                {
                    result = "BadRequest, User Exist";
                    return request;
                }
                
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return request;
            }
        }

        public UserModel Update(List<UserModel> userList, UserModel user, out string result)
        {
            try
            {
                var newUser = new UserModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Password = user.Password,
                    Basket = new BasketModel()
                };
                if(CheckUserParamsWhenEditUser(userList, user, out result))
                {
                    return newUser;
                }
                else
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
                return user;
            }
        }

        private bool CheckUserExistWhenCreateNewUser(List<UserModel> userList, UserModel user)
        {
            foreach(var u in userList)
            {
                if (u.UserName == user.UserName)
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckUserParamsWhenEditUser(List<UserModel> userList, UserModel user, out string result)
        {
            foreach(var u in userList)
            {
                if(u.Id == user.Id)
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
