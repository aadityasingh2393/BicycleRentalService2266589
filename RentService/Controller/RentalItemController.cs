using BicycleRentalSystem.RentService.BusinessLayer.Services;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/rentalitems")]
public class RentalItemController : ControllerBase
{
    private readonly IRentalItemService _rentalItemService;

    public RentalItemController(IRentalItemService rentalItemService)
    {
        _rentalItemService = rentalItemService;
    }

    [HttpGet("{rentalItemId}")]
    public ActionResult<RentalItemDto> GetRentalItem(int rentalItemId)
    {
        var rentalItem = _rentalItemService.GetRentalItem(rentalItemId);

        if (rentalItem == null)
        {
            return NotFound();
        }

        return Ok(rentalItem);
    }

    [HttpGet]
    public ActionResult<IEnumerable<RentalItemDto>> GetAllRentalItems()
    {
        var rentalItems = _rentalItemService.GetAllRentalItems();

        return Ok(rentalItems);
    }

    [HttpGet("rental/{rentalId}")]
    public ActionResult<IEnumerable<RentalItemDto>> GetRentalItemsByRental(int rentalId)
    {
        var rentalItems = _rentalItemService.GetRentalItemsByRental(rentalId);

        return Ok(rentalItems);
    }

    [HttpGet("bicycle/{bicycleId}")]
    public ActionResult<IEnumerable<RentalItemDto>> GetRentalItemsByBicycle(int bicycleId)
    {
        var rentalItems = _rentalItemService.GetRentalItemsByBicycle(bicycleId);

        return Ok(rentalItems);
    }

    [HttpPost]
    public ActionResult AddRentalItem(RentalItemDto rentalItem)
    {
        _rentalItemService.AddRentalItem(rentalItem);

        return CreatedAtAction(nameof(GetRentalItem), new { rentalItemId = rentalItem.RentalItemId }, rentalItem);
    }

    [HttpPut("{rentalItemId}")]
    public ActionResult UpdateRentalItem(int rentalItemId, RentalItemDto rentalItem)
    {
        if (rentalItemId != rentalItem.RentalItemId)
        {
            return BadRequest();
        }

        _rentalItemService.UpdateRentalItem(rentalItem);

        return NoContent();
    }

    [HttpDelete("{rentalItemId}")]
    public ActionResult DeleteRentalItem(int rentalItemId)
    {
        if (!_rentalItemService.RentalItemExists(rentalItemId))
        {
            return NotFound();
        }

        _rentalItemService.DeleteRentalItem(rentalItemId);

        return NoContent();
    }
}
