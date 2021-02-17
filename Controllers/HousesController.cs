using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using csharpgregslist.Services;
using csharpgregslist.Models;


namespace csharpgregslist.Controllers
{

  [ApiController]
  [Route("api/[controller]")]

  public class HousesController : ControllerBase
  {


    private readonly HousesService _hs;
    public HousesController(HousesService hs)
    {
      _hs = hs;
    }

    // Get
    [HttpGet]
    public ActionResult<IEnumerable<House>> getAllHouses()
    {
      try
      {
        return Ok(_hs.getAllHouses());
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // Get By Id
    [HttpGet("{houseId}")]
    public ActionResult<House> getHouseById(string houseId)
    {
      try
      {
        House houseToGet = _hs.getHouseById(houseId);
        return Ok(houseToGet);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // Post
    [HttpPost]
    public ActionResult<House> Create([FromBody] House newHouse)
    {
      try
      {
        House houseToMake = _hs.createHouse(newHouse);
        return Ok(houseToMake);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // Put
    [HttpPut("{houseId}")]
    public ActionResult<House> editHouse([FromBody] House updatedHouse, string houseId)
    {
      try
      {
        updatedHouse.Id = houseId;
        House houseToEdit = _hs.editHouse(updatedHouse);
        return Ok(houseToEdit);
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    // Delete
    [HttpDelete("{houseId}")]
    public ActionResult<String> deleteHouse(string houseId)
    {
      try
      {
        _hs.deleteHouse(houseId);
        return Ok("House Posting Successfully Delorted");
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }



  }
}