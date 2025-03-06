using InventoryService.Application.DTOS;
using InventoryService.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class InventoryItemController : ControllerBase
    {
        private readonly IInventoryItemService _service;

        public InventoryItemController(IInventoryItemService service)
        {
            _service = service;
        }
        // GET: api/<InventoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.GetInventoryItemAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Post(InventoryItemDto item)
        {
            var result = await _service.CreateAsync(item);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(InventoryItemDto item)
        {
            var result = await _service.UpdateAsync(item);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteInventoryItemAsync(id);
            return Ok();
        }
    }
}
