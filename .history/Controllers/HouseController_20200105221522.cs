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
    [HttpGet]
    public ActionResult GetAllHouses()
    {
      var db = new DatabaseContext();
      return Ok(db.SchoolHouses);
    }
    [HttpGet("{id}")]
    public ActionResult GetOneHouse(int id)
    {
      var db = new DatabaseContext();
      var schoolhouse = db.SchoolHouses.FirstOrDefault(schoolhouse => schoolhouse.Id == id);
      if (schoolhouse == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(schoolhouse);
      }
    }







  }
}