using System.Collections.Generic;

namespace universe_api.ViewModels
{
  public class CreatedStudent
  {
    public int Id { get; set; }
    public string FullName { get; set; }
    public bool PlaysQuidditch { get; set; }

    public int SchoolHouseId { get; set; }

  }
}