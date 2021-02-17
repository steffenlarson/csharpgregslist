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







  }
}