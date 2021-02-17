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


    // Create


    // Edit


    // Delete



  }
}