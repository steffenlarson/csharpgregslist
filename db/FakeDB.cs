using System.Collections.Generic;
using csharpgregslist.Models;

namespace csharpgregslist.db
{
  public class FakeDB
  {
    public static List<Car> Cars { get; set; } = new List<Car>();
  }
}