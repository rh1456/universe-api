using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using universe_api.Models;
using universe_api.ViewModels;

namespace universe_api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class StudentController : ControllerBase
  {
    [HttpGet]
    public ActionResult GetAllStudent()
    {
      var db = new DatabaseContext();
      return Ok(db.Students);
    }
    [HttpGet("{id}")]
    public ActionResult GetOneStudent(int id)
    {
      var db = new DatabaseContext();
      var student = db.Students.FirstOrDefault(student => student.Id == id);
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(student);
      }
    }
    [HttpPost]
    public ActionResult CreateStudent(NewStudent vm)
    {
      var db = new DatabaseContext();
      var schoolHouse = db.SchoolHouses.FirstOrDefault(house => house.Id == vm.SchoolHouseId);
      if (schoolHouse == null)
      {
        return NotFound();
      }
      else
      {
        var newbie = new Student
        {
          FullName = vm.FullName,
          PlaysQuidditch = vm.PlaysQuidditch,
          SchoolHouseId = vm.SchoolHouseId
        };
        db.Students.Add(newbie);
        db.SaveChanges();
        var rv = new CreatedStudent
        {
          Id = newbie.Id,
          PlaysQuidditch = newbie.PlaysQuidditch,
          SchoolHouseId = newbie.SchoolHouseId,
          FullName = newbie.FullName
        };
        return Ok(rv);
      }
    }
    [HttpPut("{id}")]
    public ActionResult UpdateStudent(Student student)
    {
      var db = new DatabaseContext();
      var prevStudent = db.Students.FirstOrDefault(student => student.Id == student.Id);
      if (prevStudent == null)
      {
        return NotFound();
      }
      else
      {
        prevStudent.FullName = student.FullName;
        prevStudent.PlaysQuidditch = student.PlaysQuidditch;
        db.SaveChanges();
        return Ok(prevStudent);
      }
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteStudent(int id)
    {
      var db = new DatabaseContext();
      var student = db.Students.FirstOrDefault(student => student.Id == student.Id);
      if (student == null)
      {
        return NotFound();
      }
      else
      {
        db.Students.Remove(student);
        db.SaveChanges();
        return Ok();
      }

    }
  }
}