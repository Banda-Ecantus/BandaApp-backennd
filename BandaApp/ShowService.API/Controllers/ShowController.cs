using Microsoft.AspNetCore.Mvc;
using ShowService.Application.Interfaces;

namespace ShowService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowService _service;
        public ShowController(IShowService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
