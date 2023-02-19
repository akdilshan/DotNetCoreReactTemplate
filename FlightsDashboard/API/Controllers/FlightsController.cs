using Core.ServiceInterfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightsService __flightService;
        public FlightsController(IFlightsService flightService)
        {
            __flightService = flightService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var flights =  await __flightService.List();
            return Ok(flights);
        }

    }
}
