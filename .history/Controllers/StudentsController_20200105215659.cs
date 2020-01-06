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
    public ActionResult CreateStudent(Student student)
    {
      var db = new DatabaseContext();
      student.Id = 0;
      db.Students.Add(student);
      db.SaveChanges();
      return Ok(student);
    }

  }
}