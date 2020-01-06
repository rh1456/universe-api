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
    [HttpPut("{id}")]
    public ActionResult UpdateSchoolHouse(SchoolHouse schoolhouse)
    {
      var db = new DatabaseContext();
      var prevSchoolHouse = db.SchoolHouses.FirstOrDefault(schoolhouse => schoolhouse.Id == schoolhouse.Id);
      if (prevSchoolHouse == null)
      {
        return NotFound();
      }
      else
      {
        prevSchoolHouse.HouseName = schoolhouse.HouseName;
        prevSchoolHouse.Color = schoolhouse.Color;
        db.SaveChanges();
        return Ok(prevSchoolHouse);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteSchoolHouse(int id)
    {
      var db = new DatabaseContext();
      var schoolhouse = db.SchoolHouses.FirstOrDefault(schoolhouse => schoolhouse.Id == schoolhouse.Id);
      if (schoolhouse == null)
      {
        return NotFound();
      }
      else
      {
        db.SchoolHouses.Remove(schoolhouse);
        db.SaveChanges();
        return Ok();
      }
    }

  }
}