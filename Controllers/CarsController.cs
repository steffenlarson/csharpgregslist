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

    [HttpGet("{carId}")]
    public ActionResult<Car> GetCarById(string carId)
    {
      try
      {
        Car carToReturn = FakeDB.Cars.Find(c => c.Id == carId);
        return Ok(carToReturn);
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
        // NOTE Find the car where the id passed equals the Id on the object
        Car foundCar = FakeDB.Cars.Find(c => c.Id == carId);

        // NOTE Once found the updated instance of the car equals (Check if something exists) if it does, Overwrite that : if not use the data from the created.
        carUpdate.Make = carUpdate.Make != null ? carUpdate.Make : foundCar.Make;
        carUpdate.Model = carUpdate.Model != null ? carUpdate.Model : foundCar.Model;
        carUpdate.Description = carUpdate.Description != null ? carUpdate.Description : foundCar.Description;

        // NOTE Return the updated instance.
        return carUpdate;
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }
  }
}
