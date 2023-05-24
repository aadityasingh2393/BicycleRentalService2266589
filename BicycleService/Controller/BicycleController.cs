using BicycleRentalSystem.BicycleService.BusinessLayer.Models;
using BicycleRentalSystem.BicycleService.BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRentalSystem.BicycleService.Controller
{
    [ApiController]
    [Route("/api/bicycle")]
    public class BicycleController : ControllerBase
    {
        private readonly IBicycleService _bicycleService;

        public BicycleController(IBicycleService bicycleService)
        {
            _bicycleService = bicycleService;
        }

        [HttpGet]
        public IActionResult GetAllBicycle()
        {
            var bicycle = _bicycleService.GetBicycles();
            return Ok(bicycle);
        }

        [HttpGet("{bicycleId}")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetBicycle(int bicycleId)
        {
            var bicycle = _bicycleService.GetBicycleById(bicycleId);

            if (bicycle == null)
            {
                return NotFound();
            }

            return Ok(bicycle);
        }

        [HttpPost]
        public IActionResult AddBicycle(BicycleDto bicycle)
        {
            _bicycleService.AddBicycle(bicycle);
            return CreatedAtAction(nameof(GetBicycle), new { bicycleId = bicycle.BicycleId }, bicycle);
        }

        [HttpPut("{bicycleId}")]
        public IActionResult UpdateBicycle(int bicycleId, BicycleDto bicycle)
        {
            if (bicycleId != bicycle.BicycleId)
            {
                return BadRequest();
            }

            _bicycleService.UpdateBicycle(bicycle);

            return NoContent();
        }

        [HttpDelete("{bicycleId}")]
        public IActionResult DeleteBicycle(int bicycleId)
        {
            var bicycle = _bicycleService.GetBicycleById(bicycleId);

            if (bicycle == null)
            {
                return NotFound();
            }

            _bicycleService.DeleteBicycle(bicycleId);

            return NoContent();
        }
    }
}
