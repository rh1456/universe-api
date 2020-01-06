using System.Collections.Generic;

namespace universe_api.ViewModels
{
  public class HouseDetails
  {
    public int Id { get; set; }
    public string HouseName { get; set; }
    public string Color { get; set; }

    public List<CreatedStudent> CreatedStudents { get; set; }
      = new List<CreatedStudent>();

  }
}