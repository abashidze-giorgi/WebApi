using DataBase;
using Domain.Actions.BasketActions;
using Domain.Actions.UserActions;
using Domain.Interfaces.BasketInterfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private protected DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            try
            {
                var users = _context.Users.ToList();
                if(users.Count == 0)
                {
                    return StatusCode(404, "No Users Found");
                }
                else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateUser")]
        public IActionResult Create([FromForm]UserModel request)
        {
            
            try
            {
                var nu = new UserActions();
                var user = nu.Create(_context.Users.ToList(), request, out string result);
                if (result == "Ok")
                {
                    var ab = new CreateBasketAction();
                    var basket = ab.Create(user);
                    _context.Baskets.Add(basket);
                    _context.SaveChanges();
                    user.BasketId = basket.Id;
                     _context.Users.Add(user);
                    _context.SaveChanges();
                    var users = _context.Users.ToList();
                    return Ok(users);
                }
                else
                {
                    return StatusCode(404, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public IActionResult Update([FromForm] UserModel user)
        {
            try
            {
                var nu = new UserActions();
                user = nu.Update(_context.Users.ToList(), user, out string result);
                if(result == "Ok")
                {
                    //var us = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();
                    //us.UserName = user.UserName;
                    //us.LastName = user.LastName;
                    //us.UserName = user.UserName;
                    //us.Password = user.Password;
                    _context.Users.Update(user);
                    //_context.Entry(us).State = EntityState.Modified;
                    _context.SaveChanges();
                    var users = _context.Users.ToList();
                    return Ok(users);
                }
                else
                {
                    return StatusCode(404, result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("DeleteUser")]
        public IActionResult Delete([FromForm]int Id) 
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == Id).FirstOrDefault();
                _context.Users.Remove(user);
                _context.SaveChanges();
                var users = _context.Users.ToList();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
