using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using universe_api.Models;
using universe_api.ViewModels;

namespace universe_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]

  public class HouseController : ControllerBase
  {
    [HttpPost]
    public ActionResult CreateHouse(SchoolHouse shcoolhouse)
    {
      var db = new DatabaseContext();
      shcoolhouse.Id = 0;
      db.SchoolHouses.Add(shcoolhouse);
      db.SaveChanges();
      return Ok(shcoolhouse);

    }
  }
}