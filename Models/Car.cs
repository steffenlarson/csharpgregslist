using System;
using System.ComponentModel.DataAnnotations;

namespace csharpgregslist.Models
{
  public class Car
  {

    // NOTE below is a constructor for the model Car.
    public Car(string make, string model, string description, int year, int price)
    {
      Make = make;
      Model = model;
      Description = description;
      Year = year;
      Price = price;
    }


    // NOTE below are the properties that belong to each car. Each car will have these properties regardless of if the user provides them or not.

    public string Make { get; set; }
    public string Model { get; set; }
    [MaxLength(50)]
    public string Description { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public int Price { get; set; }

    public string Id { get; set; } = Guid.NewGuid().ToString();


  }



}