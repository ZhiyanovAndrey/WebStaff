using WebStaff.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStaff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        //тестовый запрос
        [HttpGet("test")]
        public IActionResult Test()
        {

            string t = $"";
            return Ok($"Привет! Сервер запущен {DateTime.Now.ToString("D")} в {DateTime.Now.ToString("t")}");
        }


        private readonly Context _db;

        StaffController(Context _db)
        {
            _db = _db;
        }


        [HttpPost]
        public IActionResult CreateEmploees([FromBody] Emploee staff)
        {
            if (staff != null)
            {
                Emploee newPerson = new Emploee(staff.SureName, staff.Name, staff.ThirdName, staff.BirthDay, staff.EmploymentDate, staff.Salary);
                _db.Emploees.Add(newPerson);
                _db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        //        [HttpPost]
        //        public IActionResult CreateUser([FromBody] UserModel userModel) // UserModel получаем из тела запроса
        //        {
        //            if (userModel != null)
        //            {
        //                // получим User из фронта UserModel
        //                bool result = _usersService.Create(userModel);
        //                return result ? Ok() : NotFound();
        //            }
        //            return BadRequest();
        //        }

        //        User newUser = new User(model.Surname, model.Name, model.Email,
        //model.Password, model.Phone, model.Status, model.Photo);
        //        _db.Users.Add(newUser);
        //                _db.SaveChanges();

    }
}
