using DataBase;
using Domain.Actions.ItemActions;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private protected DataContext _context;
        public ItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            try
            {
                var itemList = _context.Items.ToList();
                if(itemList .Count > 0)
                {
                    return Ok(itemList);
                }
                else
                {
                    return StatusCode(404, "No items found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Create Computer")]
        public IActionResult CreateComputer([FromForm] ComputerModel computer)
        {
            try
            {
                var cc = new ComputerCreate();
                var comp = cc.Create(_context.Computers.ToList(), computer, out string result);
                if (result == "Ok")
                {
                    _context.Computers.Add(comp);
                    _context.SaveChanges();
                    var comps = _context.Computers.ToList();
                    return Ok(comps);
                }
                return StatusCode(404, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
