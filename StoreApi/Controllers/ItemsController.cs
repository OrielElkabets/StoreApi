using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApi.DTO;
using StoreApi.Entities.StoreDb;
using StoreApi.Entities.StoreDb.EOs;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public ItemsController(StoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ItemDTO> items = _context.Items.Select(ItemDTO.FromEO);
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            ItemsEO? item = _context.Items.FirstOrDefault(item => item.Id == id);
            if (item is null) return NotFound($"item with id {id} was not found!");

            return Ok(ItemDTO.FromEO(item));
        }

        [HttpPost("create")]
        public IActionResult Create(NewItemDTO newItem)
        {
            ItemsEO item = newItem.ToEO();
            _context.Items.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { item.Id }, ItemDTO.FromEO(item));
        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateItemDTO item)
        {
            ItemsEO? itemToUpdate = _context.Items.FirstOrDefault(item => item.Id == id);
            if (item is null) return NotFound($"item with id {id} was not found!");

            item.UpdateEO(itemToUpdate!);
            _context.SaveChanges();

            return Ok(ItemDTO.FromEO(itemToUpdate!));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            ItemsEO? item = _context.Items.FirstOrDefault(item => item.Id == id);
            if (item is null) return NotFound($"item with id {id} was not found!");

            _context.Items.Remove(item);
            _context.SaveChanges();

            return Ok($"item with {id} removed successfully");
        }
    }
}
