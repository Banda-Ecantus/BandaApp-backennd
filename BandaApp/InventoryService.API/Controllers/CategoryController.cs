using InventoryService.Application.DTOS;
using InventoryService.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InventoryService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryService _service = categoryService;

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllsAsync();
            return Ok(result);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.GetCategoryAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDto request )
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        // PUT api/<CategoryController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryDto request)
        {
            var result = await _service.UpdateAsync(request);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteCategoryAsync(id);
            return Ok();
        }
    }
}
