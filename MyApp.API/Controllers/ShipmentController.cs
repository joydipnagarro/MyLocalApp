using Microsoft.AspNetCore.Mvc;
using MyApp.API.Models;
using MyApp.API.Services;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly ShipmentService _service;

        public ShipmentController(ShipmentService service)
        {
            _service = service;
        }

        [HttpPost("search")]
        public async Task<IActionResult> GetShipments([FromBody] ShipmentFilterRequest request)
        {
            var data = await _service.GetShipmentDetails(request);

            return Ok(new ApiResponse<IEnumerable<ShipmentDto>>
            {
                Success = true,
                Data = data,
                Message = null
            });
        }

        
    }
}