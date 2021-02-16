using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using csharpgregslist.db;
using csharpgregslist.Models;

namespace csharpgregslist.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {

    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAction()
    {
      try
      {
        return Ok(FakeDB.Cars);
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }


    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        FakeDB.Cars.Add(newCar);
        return Ok(newCar);
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{carId}")]
    public ActionResult<string> DeleteCar(string carId)
    {
      try
      {
        Car carToRemove = FakeDB.Cars.Find(c => c.Id == carId);
        if (FakeDB.Cars.Remove(carToRemove))
        {
          return Ok("Car Removed");
        };
        throw new System.Exception("Car does not exist");
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpPut("{carId}")]
    public ActionResult<Car> EditCar([FromBody] Car carUpdate, string carId)
    {
      try
      {
        Car foundCar = FakeDB.Cars.Find(c => c.Id == carId);
        carUpdate.Make = carUpdate.Make != null ? carUpdate.Make : foundCar.Make;
        carUpdate.Model = carUpdate.Model != null ? carUpdate.Model : foundCar.Model;
        carUpdate.Description = carUpdate.Description != null ? carUpdate.Description : foundCar.Description;
        carUpdate.Year = carUpdate.Year != null ? carUpdate.Year : foundCar.Year;
        carUpdate.Price = carUpdate.Price != null ? carUpdate.Price : foundCar.Price;

      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }
  }
}
