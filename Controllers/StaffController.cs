using WebStaff.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStaff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        // тестовый запрос
        //[HttpGet("test")]
        //public IActionResult Test()
        //{

        //    string t = $"";
        //    return Ok($"Привет! Сервер запущен {DateTime.Now.ToString("D")} в {DateTime.Now.ToString("t")}");
        //}

        private readonly Context _db;

        StaffController(Context _db)
        {
            _db = _db;
        }


        [HttpPost("create")]
        IActionResult CreateEmploees([FromBody] Emploees staff)
        {
            if (staff != null)
            {
                Emploees newPerson = new Emploees(staff.SureName, staff.Name, staff.ThirdName, staff.BirthDay, staff.EmploymentDate, staff.Salary);
                _db.Emploees.Add(newPerson);
                _db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }




    }
}
