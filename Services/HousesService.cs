using System;
using System.Collections.Generic;
using csharpgregslist.db;
using csharpgregslist.Models;


namespace csharpgregslist.Services
{
  public class HousesService
  {


    // GetAll
    public IEnumerable<House> getAllHouses()
    {
      return FakeDB.Houses;
    }

    // GetById
    public House getHouseById(string id)
    {
      House houseToGet = FakeDB.Houses.Find(h => h.Id == id);
      if (houseToGet == null)
      {
        throw new Exception("Invalid Id");
      }
      return houseToGet;
    }

    // Create
    public House createHouse(House newHouse)
    {
      FakeDB.Houses.Add(newHouse);
      return newHouse;
    }

    // Edit
    public House editHouse(House updatedHouse)
    {
      House houseToUpdate = FakeDB.Houses.Find(h => h.Id == updatedHouse.Id);
      if (houseToUpdate == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDB.Houses.Remove(houseToUpdate);
      FakeDB.Houses.Add(updatedHouse);
      return updatedHouse;
    }

    // Delete
    public string deleteHouse(string houseId)
    {
      House houseToDelete = FakeDB.Houses.Find(h => h.Id == houseId);
      if (houseToDelete == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDB.Houses.Remove(houseToDelete);
      return "House Posting Successfully Delorted";
    }


  }
}