using InventoryService.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                var result = await _service.GetAllsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InventoryController>
        [HttpPost]
        public Task<IActionResult> Post()
        {
            // Method not implemented
            throw new NotSupportedException("This method is not implemented.");
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public Task<IActionResult> Put(int id, [FromBody] string value)
        {
            // Method not implemented
            throw new NotSupportedException("This method is not implemented.");
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            // Method not implemented
            throw new NotSupportedException("This method is not implemented.");
        }
    }
}
