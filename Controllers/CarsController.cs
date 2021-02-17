using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using csharpgregslist.db;
using csharpgregslist.Services;
using csharpgregslist.Models;

namespace csharpgregslist.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {



    private readonly CarsService _cs;
    public CarsController(CarsService cs)
    {
      _cs = cs;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
      try
      {
        return Ok(_cs.Get());
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
        Car carToReturn = _cs.getCar(carId);
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
        Car createdCar = _cs.Create(newCar);
        return Ok(createdCar);
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    // REVIEW This is how I originally handled the edit. In the model made the inputs for the integers required because cannot do a null check on them. 
    // I am going to copy what Mark did in lecture today for the actual edit because we added the services layer into the equation.


    // [HttpPut("{carId}")]
    // public ActionResult<Car> EditCar([FromBody] Car carUpdate, string carId)
    // {
    //   try
    //   {
    //     // NOTE Find the car where the id passed equals the Id on the object
    //     Car foundCar = FakeDB.Cars.Find(c => c.Id == carId);

    //     // NOTE Once found the updated instance of the car equals (Check if something exists) if it does, Overwrite that : if not use the data from the created.
    //     carUpdate.Make = carUpdate.Make != null ? carUpdate.Make : foundCar.Make;
    //     carUpdate.Model = carUpdate.Model != null ? carUpdate.Model : foundCar.Model;
    //     carUpdate.Description = carUpdate.Description != null ? carUpdate.Description : foundCar.Description;

    //     // NOTE Return the updated instance.
    //     return carUpdate;
    //   }
    //   catch (System.Exception err)
    //   {

    //     return BadRequest(err.Message);
    //   }
    // }


    [HttpPut("{carId}")]
    public ActionResult<Car> editCar([FromBody] Car updatedCar, string carId)
    {
      try
      {
        updatedCar.Id = carId;
        Car carToEdit = _cs.Edit(updatedCar);
        return Ok(carToEdit);
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
        _cs.Delete(carId);
        return Ok("Successfully Delorted");
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }





  }
}
