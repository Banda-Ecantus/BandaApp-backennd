using InventoryService.Application.DTOS;
using InventoryService.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryItemController(IInventoryItemService service) : ControllerBase
    {
        private readonly IInventoryItemService _service = service;

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
        public async Task<IActionResult> Post([FromBody] InventoryItemDto item)
        {
            var result = await _service.CreateAsync(item);
            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] InventoryItemDto item)
        {
            var result = await _service.UpdateAsync(item);
            if (result == null)
            {
                return NotFound();
            }

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
