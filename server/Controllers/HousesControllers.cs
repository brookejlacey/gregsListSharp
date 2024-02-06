using gregsListSharp.Models;

namespace gregstListSharp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HousesController : ControllerBase
{
    private readonly HousesService housesService;

    public HousesController(HousesService housesService)
    {
        this.housesService = housesService;
    }

    [HttpGet]
    public ActionResult<List<House>> GetAllHouses()
    {
        try
        {
            List<House> houses = housesService.GetAllHouses();
            return Ok(houses);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{houseId}")]
    public ActionResult<House> GetHouseById(int houseId)
    {
        try
        {
            House house = housesService.GetHouseById(houseId);
            return Ok(house);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    public ActionResult<House> CreateHouse([FromBody] House houseData)
    {
        try
        {
            House house = housesService.CreateHouse(houseData);
            return Ok(house);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{houseId}")]
    public ActionResult<string> RemoveHouse(int houseId)
    {
        try
        {
            string message = housesService.RemoveHouse(houseId);
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{houseId}")]
    public ActionResult<House> UpdateHouse([FromBody] House updateData, int houseId)
    {
        try
        {
            updateData.Id = houseId;
            House update = housesService.UpdateHouse(updateData);
            return Ok(update);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


}