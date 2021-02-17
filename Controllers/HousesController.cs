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
    // [HttpGet("{houseId}")]
    // public ActionResult<House> getHouseById(string houseId)
    // {
    //   try
    //   {
    //     House houseToGet = _hs.getHouseById(houseId);
    //     return Ok(houseToGet);
    //   }
    //   catch (Exception e)
    //   {

    //     return BadRequest(e.Message);
    //   }
    // }

    // Post


    // Put


    // Delete







  }
}