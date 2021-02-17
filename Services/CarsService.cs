using System;
using System.Collections.Generic;
using csharpgregslist.db;
using csharpgregslist.Models;

namespace csharpgregslist.Services
{


  public class CarsService
  {

    // Get All
    public IEnumerable<Car> Get()
    {
      return FakeDB.Cars;
    }


    // Get By Id
    public Car getCar(string id)
    {
      Car carToGet = FakeDB.Cars.Find(c => c.Id == id);
      if (carToGet == null)
      {
        throw new Exception("Invalid Id");
      }
      return carToGet;
    }


    // Create
    public Car Create(Car newCar)
    {
      FakeDB.Cars.Add(newCar);
      return newCar;
    }


    // Edit
    public Car Edit(Car updated)
    {
      Car carToUpdate = FakeDB.Cars.Find(c => c.Id == updated.Id);
      if (carToUpdate == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDB.Cars.Remove(carToUpdate);
      FakeDB.Cars.Add(updated);
      return updated;
    }


    // Delete
    public string Delete(string id)
    {
      Car carToDelete = FakeDB.Cars.Find(c => c.Id == id);
      if (carToDelete == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDB.Cars.Remove(carToDelete);
      return "Successfully Delorted";
    }

  }


}