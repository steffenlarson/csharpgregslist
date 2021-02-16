using System;
using System.ComponentModel.DataAnnotations;

namespace csharpgregslist.Models
{
  public class Car
  {
    public Car(string make, string model, string description, int year, int price)
    {
      Make = make;
      Model = model;
      Description = description;
      Year = year;
      Price = price;
    }
    public string Make { get; set; }
    public string Model { get; set; }
    [MaxLength(50)]
    public string Description { get; set; }
    public int Year { get; set; }
    public int Price { get; set; }

    public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}