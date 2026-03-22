using Microsoft.AspNetCore.Mvc;
using MyApp.API.Services;
using MyApp.API.Models;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TestService _service;

        public TestController(TestService service)
        {
            _service = service;
        }

        [HttpPost("shipments")]
        public async Task<IActionResult> GetShipments([FromBody] ShipmentFilterRequest request)
        {
            var result = await _service.GetShipmentDetails(request);
            return Ok(result);
        }



    }
}