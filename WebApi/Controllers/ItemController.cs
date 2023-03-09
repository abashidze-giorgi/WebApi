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

        [HttpGet("Computers/GetAll")]
        public IActionResult GetComps()
        {
            try
            {
                var compList = _context.Computers.ToList();


                if(compList.Count > 0)
                {
                    return Ok(compList);
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
        public IActionResult CreateComp([FromForm] ComputerModel computer)
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

        [HttpGet("Telephones/GetAll")]
        public IActionResult GetPhones()
        {
            try
            {
                var phoneList = _context.Telephones.ToList();


                if (phoneList.Count > 0)
                {
                    return Ok(phoneList);
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

        [HttpPost("Create Phone")]
        public IActionResult CreatePhones([FromForm] TelephoneModel phone)
        {
            try
            {
                var cc = new PhoneCreate();
                var ph = cc.Create(_context.Telephones.ToList(), phone, out string result);
                if (result == "Ok")
                {
                    _context.Telephones.Add(ph);
                    _context.SaveChanges();
                    var phones = _context.Telephones.ToList();
                    return Ok(phones);
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
