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
                var cc = new ComputerEditor();
                var itemList = _context.Items.ToList();
                var comp = cc.CreateItem(computer, itemList);
                if (comp != null)
                {
                    var comps = new List<ItemModel> { comp };
                    _context.Items.AddRange(comps);
                    _context.SaveChanges();
                    var p = _context.Telephones.ToList();
                    var c = _context.Computers.ToList();
                    var a = new List<ItemModel>();
                    a.AddRange(c);
                    a.AddRange(p);
                    return Ok(a);
                }
                return StatusCode(404, "BadRequest");
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
                var cc = new PhoneEditor();
                var itemList = _context.Items.ToList();
                var newPhone = cc.CreateItem(phone, itemList);
                if (newPhone != null)
                {
                    var comps = new List<ItemModel> { newPhone };
                    _context.Items.AddRange(comps);
                    _context.SaveChanges();
                    var p = _context.Telephones.ToList();
                    var c = _context.Computers.ToList();
                    var a = new List<ItemModel>();
                    a.AddRange(c);
                    a.AddRange(p);
                    return Ok(a);
                }
                return StatusCode(404, "BadRequest");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
